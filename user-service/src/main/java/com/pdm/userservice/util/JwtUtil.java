package com.pdm.userservice.util;


import io.jsonwebtoken.Claims;
import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import io.jsonwebtoken.security.Keys;
import org.springframework.stereotype.Component;

import javax.crypto.SecretKey;
import java.nio.charset.StandardCharsets;
import java.util.Base64;
import java.util.Date;
import java.util.function.Function;

@Component
public class JwtUtil {

    private final String SECRET_KEY = "mySuperSecretKey1234567890123456";
    private final SecretKey key = Keys.hmacShaKeyFor(SECRET_KEY.getBytes(StandardCharsets.UTF_8));

    public String generateToken(String username, String role) {
        return Jwts.builder()
                .setSubject(username)
                .claim("role", role) // Store role in token
                .setIssuedAt(new Date())
                .setExpiration(new Date(System.currentTimeMillis() + 1000 * 60 * 60)) // 1 hour expiry
                .signWith(SignatureAlgorithm.HS256, key)
                .compact();
    }
//
//    public String extractUsername(String token) {
//        return extractClaim(token, Claims::getSubject);
//    }

//    public String extractRole(String token) {
//        return extractClaim(token, claims -> claims.get("role", String.class));
//    }

//    private <T> T extractClaim(String token, Function<Claims, T> claimsResolver) {
//        final Claims claims = Jwts.parser()
//                .setSigningKey(SECRET_KEY)
//                .build()
//                .parseSignedClaims(token)
//                .getPayload();
//
//
//        return claimsResolver.apply(claims);
//    }

//    public boolean validateToken(String token, String username) {
//        return extractUsername(token).equals(username) && !isTokenExpired(token);
//    }

//    private boolean isTokenExpired(String token) {
//        return extractClaim(token, Claims::getExpiration).before(new Date());
//    }
}
