package com.example.demo.model;

public class SolicitudDTO {
    private String tipoSolicitud;
    private String descripcion;
    private String fechaSolicitud;
    private String estado;

    public SolicitudDTO(){}

    public SolicitudDTO(String tipoSolicitud,String descripcion, String fechaSolicitud, String estado){
        this.tipoSolicitud=tipoSolicitud;
        this.descripcion=descripcion;
        this.fechaSolicitud=fechaSolicitud;
        this.estado=estado;
    }

    public String getTipoSolicitud() {
        return tipoSolicitud;
    }

    public void setTipoSolicitud(String tipoSolicitud) {
        this.tipoSolicitud = tipoSolicitud;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public String getFechaSolicitud() {
        return fechaSolicitud;
    }

    public void setFechaSolicitud(String fechaSolicitud) {
        this.fechaSolicitud = fechaSolicitud;
    }

    public String getEstado() {
        return estado;
    }

    public void setEstado(String estado) {
        this.estado = estado;
    }
}
