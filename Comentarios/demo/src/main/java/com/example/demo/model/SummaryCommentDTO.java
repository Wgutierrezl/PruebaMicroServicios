package com.example.demo.model;

public class SummaryCommentDTO {
    private Comentarios comentarios;
//    private SolicitudDTO solicitudDTO;
    private UsuarioDTO usuarioDTO;

    public SummaryCommentDTO(){}

    public SummaryCommentDTO(Comentarios comentarios, UsuarioDTO usuarioDTO){
        this.comentarios=comentarios;
        this.usuarioDTO=usuarioDTO;
    }

    public Comentarios getComentarios() {
        return comentarios;
    }

    public void setComentarios(Comentarios comentarios) {
        this.comentarios = comentarios;
    }

    public UsuarioDTO getUsuarioDTO() {
        return usuarioDTO;
    }

    public void setUsuarioDTO(UsuarioDTO usuarioDTO) {
        this.usuarioDTO = usuarioDTO;
    }
}
