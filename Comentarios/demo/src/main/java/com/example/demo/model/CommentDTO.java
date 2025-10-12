package com.example.demo.model;

import jakarta.persistence.Column;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;

public class CommentDTO {
    private int solicitudId;
    private String mensaje;

    public  CommentDTO(){}

    public  CommentDTO(int solicitudId, String mensaje){
        this.solicitudId=solicitudId;
        this.mensaje=mensaje;
    }

    public int getSolicitudId() {
        return solicitudId;
    }

    public void setSolicitudId(int solicitudId) {
        this.solicitudId = solicitudId;
    }

    public String getMensaje() {
        return mensaje;
    }

    public void setMensaje(String mensaje) {
        this.mensaje = mensaje;
    }
}
