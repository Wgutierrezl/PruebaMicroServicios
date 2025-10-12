package com.example.demo.Interface.IRepository;

import com.example.demo.model.Comentarios;
import org.springframework.scheduling.config.Task;
import java.util.List;
import java.awt.*;

public interface IRepositoryComment {
    Comentarios NewComment(Comentarios comentarios);
    List<Comentarios> GetCommentsByRequestId(int requestId);
    void SaveChangesAsync();
}
