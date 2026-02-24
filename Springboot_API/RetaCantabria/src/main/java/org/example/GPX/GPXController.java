package org.example.GPX;

import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;
import org.slf4j.Logger;

@RestController
@RequestMapping("/gpx")
public class GPXController {
    private static final Logger log= LoggerFactory.getLogger(GPXController.class);
    private final GPXService gpxService;

    @Autowired
    public GPXController(GPXService gpxService) {
        this.gpxService = gpxService;
    }

    @PostMapping("/upload")
    public ResponseEntity<String> uploadGPX(@RequestParam("file") MultipartFile file) {
        try {
            log.info("GPX Recibido");
            gpxService.processAndSaveGPX(file);
            return ResponseEntity.ok("Archivo GPX procesado correctamente");
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body("Error procesando GPX: " + e.getMessage());
        }
    }
}
