package com.example.demo.Repository;

import com.example.demo.model.Comentarios;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


public interface CommentJPaRepository extends JpaRepository<Comentarios,Integer> {
    List<Comentarios> findBySolicitudId(int solicitudId);
}
