package com.example.demo.Service;

import com.example.demo.Interface.IRepository.IRepositoryComment;
import com.example.demo.Interface.IService.IServiceComment;
import com.example.demo.model.Comentarios;
import com.example.demo.model.CommentDTO;
import com.example.demo.model.SummaryCommentDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;

@Service
public class CommetService implements IServiceComment {

    @Autowired
    private IRepositoryComment _repo;

    @Autowired
    private UserService _userservice;

    @Override
    public Comentarios AddNewComment(CommentDTO commentDTO, String userId) {
        var comment = new Comentarios();


        comment.setUsuarioId(userId);
        comment.setSolicitudId(commentDTO.getSolicitudId());
        comment.setMensaje(commentDTO.getMensaje());
        comment.setFecha(LocalDateTime.now());

        var commentCreated = _repo.NewComment(comment);

        if (commentCreated == null) {
            return null;
        }

        return commentCreated;

    }

    @Override
    public List<SummaryCommentDTO> GetCommentsByRequesyId(int RequestId) {

        var comment=_repo.GetCommentsByRequestId(RequestId);
        if(comment==null || comment.isEmpty()){
            return null;
        }

        List<SummaryCommentDTO> summary = new ArrayList<>();
        for(Comentarios item: comment){

            var user=_userservice.getUsuarioById(item.getUsuarioId());

            if(user==null){
                continue;
            }

            SummaryCommentDTO dto=new SummaryCommentDTO(item,user);
            summary.add(dto);

        }

        return summary;
    }
}