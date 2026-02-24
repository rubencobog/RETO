package org.example.QRGenerator;

import org.eclipse.jgit.api.Git;
import org.eclipse.jgit.api.errors.GitAPIException;
import org.eclipse.jgit.transport.UsernamePasswordCredentialsProvider;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.core.io.Resource;
import org.springframework.core.io.UrlResource;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.io.File;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.nio.file.StandardCopyOption;
import java.util.Map;
import java.util.UUID;

@RestController
@RequestMapping("/api/pdf")
public class QRController {
    private static final Logger logger = LoggerFactory.getLogger(QRController.class);
    private static final String pdf="pdfs";
    private static final String GITHUB_REPO = "https://github.com/SaulGarciaaaa/FichasPDF.git";
    private static final String GITHUB_USER = "SaulGarciaaaa";
    private static final String GITHUB_TOKEN = "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";
    @PostMapping
    public ResponseEntity<?> uploadPdf(@RequestParam("file") MultipartFile file) throws IOException, GitAPIException {
     if(!"application/pdf".equals(file.getContentType())){
         return ResponseEntity.badRequest().build();
     }
        Files.createDirectories(Paths.get(pdf));
        String fileName = UUID.randomUUID()+".pdf";
        Path path = Paths.get(pdf,fileName);
        Files.write(path, file.getBytes());
        Path localPath = Paths.get("pdfs", fileName);
        File repoDir = new File("temp-repo");
        if(!repoDir.exists()) {
            Git.cloneRepository()
                    .setURI(GITHUB_REPO)
                    .setDirectory(repoDir)
                    .call();
        }
        Path dest = repoDir.toPath().resolve(fileName);
        Files.copy(localPath, dest, StandardCopyOption.REPLACE_EXISTING);
        Git git = Git.open(repoDir);
        git.add().addFilepattern(fileName).call();
        git.commit().setMessage("Agregado PDF: " + fileName).call();
        git.push()
                .setCredentialsProvider(new UsernamePasswordCredentialsProvider(GITHUB_USER, GITHUB_TOKEN))
                .call();
        String url = "https://github.com/SaulGarciaaaa/FichasPDF/blob/main/"+ fileName;

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
