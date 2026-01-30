package org.example.GPX;

import jakarta.transaction.Transactional;
import org.example.Entidades.Ruta;
import org.example.Entidades.TrackPoint;
import org.example.Entidades.Usuario;
import org.example.Entidades.Waypoint;
import org.example.Servicio.RutaService;
import org.example.Servicio.TrackPointService;
import org.example.Servicio.UsuarioService;
import org.example.Servicio.WaypointService;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.Node;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.InputStream;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.List;

@Service
public class GPXService {
    @Transactional
    public void processAndSaveGPX(MultipartFile file) {
        UsuarioService opusuario = SpringContext.getBean(UsuarioService.class);
        WaypointService opwaypoint = SpringContext.getBean(WaypointService.class);
        RutaService opruta = SpringContext.getBean(RutaService.class);
        TrackPointService optrackpoint = SpringContext.getBean(TrackPointService.class);
        List<Usuario> usuarios = null;
        Usuario usuario = null;
        DateTimeFormatter formatter =
                DateTimeFormatter.ofPattern("yyyy-MM-dd HH:mm:ss");
        try (InputStream inputStream = file.getInputStream()) {
            // Parseador de DOM para leer el GPX o XML
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setNamespaceAware(true);// para trabajar con etiquetas
            DocumentBuilder builder = factory.newDocumentBuilder();
            // Lectura del documento
            Document document = builder.parse(inputStream);// Paseo del XML
            document.getDocumentElement().normalize();

            // Leer la metadata
            Node metadataNode = document.getElementsByTagNameNS("*", "metadata").item(0);
            if (metadataNode == null || metadataNode.getNodeType() != Node.ELEMENT_NODE) {
                return;
            }
            Element metadata = (Element) metadataNode;
            String tipoRegistro = getValue(metadata, "tipoRegistro");
            String nombreRuta = getValue(metadata, "nombreRuta");
            String wikiloc = getValue(metadata, "enlaceWikiloc");
            String emailAutor = getValue(metadata, "author");
            String fechaCreacion = getValue(metadata, "fechaCreacionGPX");
            List<Usuario> lista = opusuario.buscar("email", emailAutor);
            if (lista.isEmpty()) {
                return;
            }
            usuario = (Usuario)lista;
            // ===== RUTA =====
            Ruta ruta = new Ruta();
            ruta.setNombre(nombreRuta);
            ruta.setUsuarioIdusuario(usuario);
            opruta.crear(ruta);
            // ===== WAYPOINTS =====
            NodeList wptList = document.getElementsByTagNameNS("*", "wpt");
            for (int i = 0; i < wptList.getLength(); i++) {
                Element wpt = (Element) wptList.item(i);
                String latitudW = wpt.getAttribute("latitud");
                String longitudW = wpt.getAttribute("longitud");
                String elevacionW = wpt.getAttribute("elevacion");

                String timestampW = getValue(wpt, "timeestamp");
                String nombreW = getValue(wpt, "nombre");
                String descripcionW = getValue(wpt, "descripcion");

                Waypoint way = new Waypoint();
                way.setNombre(nombreW);
                way.setDescripcion(descripcionW);
                way.setElevacion(Integer.parseInt(elevacionW));
                way.setLatitud(Double.parseDouble(latitudW));
                way.setLongitud(Double.parseDouble(longitudW));
                way.setTimestamp(LocalDateTime.parse(timestampW, formatter));
                way.setRuta(ruta);
                opwaypoint.crear(way);
            }
            // ===== TRACKPOINTS =====
            NodeList trkList = document.getElementsByTagNameNS("*", "trk");
            for (int i = 0; i < trkList.getLength(); i++) {
                Element trk = (Element) trkList.item(i);
                String latitudT = trk.getAttribute("latitud");
                String longitudT = trk.getAttribute("longitud");
                String elevacionT = trk.getAttribute("elevacion");
                String timestampTT = getValue(trk, "timeestamp");
                TrackPoint track = new TrackPoint();
                track.setLatitud(Double.parseDouble(latitudT));
                track.setLongitud(Double.parseDouble(longitudT));
                track.setElevacion(Integer.parseInt(elevacionT));
                track.setTimestamp(LocalDateTime.parse(timestampTT, formatter));
                track.setRuta(ruta);
                optrackpoint.crear(track);
            }
            System.out.println("Se creo correctamente");
        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }

    private static String getValue(Element element, String tagName) {
        NodeList list = element.getElementsByTagNameNS("*", tagName);
        if (list.getLength() > 0) {
            return list.item(0).getTextContent();
        }
        return null;
    }
}
