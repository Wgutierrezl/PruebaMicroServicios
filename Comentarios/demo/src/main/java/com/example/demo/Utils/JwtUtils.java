package com.example.demo.Utils;

import io.jsonwebtoken.Claims;
import io.jsonwebtoken.security.Keys;
import io.jsonwebtoken.Jwts;
import javax.crypto.SecretKey;
import java.nio.charset.StandardCharsets;

public class JwtUtils {
    private static final String SECRET_KEY = "HH24qJLS/mRBsykjM9LG6e4qEOLoVOBkwbaQzRdZcM3XX3lK62mTYqGseMmrr16/24wUdOHEg+SxxNahr/RNaQ=="; // misma que en appsettings.json

    public static Claims validateToken(String token) {
        SecretKey key = Keys.hmacShaKeyFor(SECRET_KEY.getBytes(StandardCharsets.UTF_8));
        return Jwts.parserBuilder()
                .setSigningKey(key)
                .build()
                .parseClaimsJws(token)
                .getBody();
    }
}
