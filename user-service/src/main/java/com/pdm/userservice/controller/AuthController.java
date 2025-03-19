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

           System.out.println(username + " " + password);
           User user = userService.validateUser(username, password, "");

           if (user != null) {
               return jwtUtil.generateToken(user.getUsername(), user.getRole());
           }
           throw new RuntimeException("Invalid credentials");
       } catch (Exception e) {
           log.error("e",e);
           return e.getMessage();
       }
    }
}
