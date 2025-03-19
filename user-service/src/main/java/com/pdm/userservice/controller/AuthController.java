package com.pdm.userservice.controller;

import com.pdm.userservice.model.User;
import com.pdm.userservice.service.UserService;
import com.pdm.userservice.util.JwtUtil;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/api/auth")
public class AuthController {

    private static final Logger log = LoggerFactory.getLogger(AuthController.class);
    @Autowired
    private UserService userService;

    @Autowired
    private JwtUtil jwtUtil;

    @PostMapping("/login")
    public String login(@RequestParam String username, @RequestParam String password) {
       try {

           User user = userService.validateUser(username, password);


           String tokenString = jwtUtil.generateToken(user.getUsername(), user.getRole());

           System.err.println("User name: "+ jwtUtil.extractUsername(tokenString));
           System.err.println("User Role: "+ jwtUtil.extractRole(tokenString));

           if (user != null) {
               return tokenString;
           }
           throw new RuntimeException("Invalid credentials");
       } catch (Exception e) {
           log.error("e",e);
           return e.getMessage();
       }
    }
}
