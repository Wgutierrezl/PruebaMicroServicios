package com.example.demo.Interface.IRepository;

import com.example.demo.Repository.CommentJPaRepository;
import com.example.demo.model.Comentarios;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class CommentRepositoy implements IRepositoryComment {

    @Autowired
    private CommentJPaRepository _repo;

    @Override
    public Comentarios NewComment(Comentarios comentarios) {
        return  _repo.save(comentarios);
    }

    @Override
    public List<Comentarios> GetCommentsByRequestId(int requestId) {
        return _repo.findBySolicitudId(requestId);
    }

    @Override
    public void SaveChangesAsync() {

    }
}
