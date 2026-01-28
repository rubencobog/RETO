package org.example.GPX;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.multipart.MultipartFile;

@RestController
@RequestMapping("/gpx")
public class GPXController {

    private final GPXService gpxService;

    @Autowired
    public GPXController(GPXService gpxService) {
        this.gpxService = gpxService;
    }

    @PostMapping("/upload")
    public ResponseEntity<String> uploadGPX(@RequestParam("file") MultipartFile file) {
        try {
            gpxService.processAndSaveGPX(file);
            return ResponseEntity.ok("Archivo GPX procesado correctamente");
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR)
                    .body("Error procesando GPX: " + e.getMessage());
        }
    }
}
