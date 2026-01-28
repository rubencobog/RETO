package org.example.GPX;

import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.io.IOException;
import java.nio.file.Path;
import java.nio.file.Paths;

@Service
public class GPXService {

    private final Path gpxStorage = Paths.get("src/main/resources/gpx");

    public void processAndSaveGPX(MultipartFile file) throws IOException {

    }
}
