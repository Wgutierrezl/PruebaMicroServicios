package com.example.demo.Interface.IService;

import com.example.demo.model.Comentarios;
import com.example.demo.model.CommentDTO;
import com.example.demo.model.SummaryCommentDTO;
import org.springframework.scheduling.config.Task;

import java.util.List;

public interface IServiceComment {
    Comentarios AddNewComment(CommentDTO commentDTO,String userId);
    List<SummaryCommentDTO> GetCommentsByRequesyId(int RequestId);
}
