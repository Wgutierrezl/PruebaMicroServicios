package com.example.demo.model;

import jakarta.persistence.*;
import java.time.LocalDateTime;

@Entity
@Table(name = "Comentarios")
public class Comentarios {  // ✅ Cambiar a PascalCase (nombre de clase)

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "ComentarioId")
    private int comentarioId;

    @Column(name = "UsuarioId")
    private String usuarioId;

    @Column(name = "SolicitudId")
    private int solicitudId;

    @Column(name = "Mensaje")
    private String mensaje;

    @Column(name = "Fecha")
    private LocalDateTime fecha;

    public Comentarios() {}

    public Comentarios(int comentarioId, String usuarioId, int solicitudId, String mensaje, LocalDateTime fecha) {
        this.comentarioId = comentarioId;
        this.usuarioId = usuarioId;
        this.solicitudId = solicitudId;
        this.mensaje = mensaje;
        this.fecha = fecha;
    }

    // ✅ CORREGIDO - Usar `this` para asignar a los campos de la clase
    public int getComentarioId() {
        return comentarioId;
    }

    public void setComentarioId(int comentarioId) {
        this.comentarioId = comentarioId;  // ✅ this.comentarioId se refiere al campo de la clase
    }

    public String getUsuarioId() {
        return usuarioId;
    }

    public void setUsuarioId(String usuarioId) {
        this.usuarioId = usuarioId;  // ✅ this.usuarioId se refiere al campo de la clase
    }

    public int getSolicitudId() {
        return solicitudId;
    }

    public void setSolicitudId(int solicitudId) {
        this.solicitudId = solicitudId;  // ✅ this.solicitudId se refiere al campo de la clase
    }

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;  // ✅ this.mensaje se refiere al campo de la clase
    }

    public LocalDateTime getFecha() {
        return fecha;
    }

    public void setFecha(LocalDateTime fecha) {
        this.fecha = fecha;  // ✅ this.fecha se refiere al campo de la clase
    }
}