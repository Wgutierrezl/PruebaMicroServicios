package com.example.demo.controller;

import com.example.demo.Interface.IService.IServiceComment;
import com.example.demo.model.Comentarios;
import com.example.demo.model.CommentDTO;
import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.security.SecurityRequirement;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.security.core.Authentication;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.HttpClientErrorException;
import org.springframework.web.client.HttpServerErrorException;

@RestController
@RequestMapping("/api/Comentarios")
@Tag(name = "Comentarios", description = "API para gestión de comentarios")
public class ComentarioController {

    @Autowired
    private IServiceComment _service;

    @PostMapping("/CrearNuevoComentario")
    @PreAuthorize("isAuthenticated()")
    @Operation(
            summary = "Crear nuevo comentario",
            description = "Crea un nuevo comentario requiriendo autenticación JWT",
            security = @SecurityRequirement(name = "bearerAuth")
    )
    public ResponseEntity<?> NewComment(@RequestBody CommentDTO commentDTO) {

        Authentication authentication = SecurityContextHolder.getContext().getAuthentication();
        String userId = authentication.getName();

        System.out.println("Usuario autenticado: " + userId);
        System.out.println("Roles: " + authentication.getAuthorities()); // Para debug


        var comment = _service.AddNewComment(commentDTO,userId);
        if(comment == null) {
            return ResponseEntity.badRequest().body("No hemos logrado crear el comentario");
        }

        return ResponseEntity.ok(comment);
    }

    @GetMapping("ObtenerComentariosPorSolicitudId/{id}")
    @PreAuthorize("isAuthenticated()")
    @Operation(
            summary = "Obtener comentarios por solicitud",
            description = "Devuelve la lista de comentarios de una solicitud específica",
            security = @SecurityRequirement(name = "bearerAuth")
    )
    public ResponseEntity<?> GetCommentsBySolicitudId(@PathVariable("id") int solicitudId) {

        try {
            var comentariosResumen = _service.GetCommentsByRequesyId(solicitudId);

            if (comentariosResumen == null || comentariosResumen.isEmpty()) {
                return ResponseEntity.noContent().build(); // 204 No Content si no hay comentarios
            }

            return ResponseEntity.ok(comentariosResumen);

        } catch (Exception ex) {
            // Manejo de errores genérico
            return ResponseEntity.status(500).body("Error al obtener los comentarios: " + ex.getMessage());
        }
    }
}
