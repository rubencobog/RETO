package org.example.QRGenerator;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.core.io.Resource;
import org.springframework.core.io.UrlResource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Map;
import java.util.UUID;

@RestController
@RequestMapping("/api/pdf")
public class QRController {
    private static final Logger logger = LoggerFactory.getLogger(QRController.class);
    private static final String pdf="pdfs";
    @PostMapping
    public ResponseEntity<?> uploadPdf(@RequestParam("file") MultipartFile file) throws IOException {
     if(!"application/pdf".equals(file.getContentType())){
         return ResponseEntity.badRequest().build();
     }
        Files.createDirectories(Paths.get(pdf));
        String fileName = UUID.randomUUID()+".pdf";
        Path path = Paths.get(pdf,fileName);
        Files.write(path, file.getBytes());
        String url = "http://192.168.6.1:5050/api/pdf/pdfs/" + fileName;

        logger.info("PDF subido correctamente: {}", fileName);
        logger.info("URL pública: {}", url);
        return ResponseEntity.ok(Map.of("url",url));
    }
    @GetMapping("/pdfs/{fileName}")
    public ResponseEntity<Resource> getPdf(@PathVariable("fileName") String fileName)throws IOException{
     Path path = Paths.get(pdf,fileName);
     Resource resource = new UrlResource(path.toUri());
     if(!resource.exists()){
         return ResponseEntity.notFound().build();
     }
     return ResponseEntity.ok()
             .contentType(MediaType.APPLICATION_PDF)
             .header(HttpHeaders.CONTENT_DISPOSITION, "inline; filename=\"" + fileName+ "\"")
             .body(resource);
    }
}
