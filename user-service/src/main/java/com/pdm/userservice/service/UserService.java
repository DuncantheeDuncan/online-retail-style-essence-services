package com.pdm.userservice.service;

import com.pdm.userservice.model.User;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserService {

    private static final Logger log = LoggerFactory.getLogger(UserService.class);
    private final List<User> users = new ArrayList<>();

    //Add users
    public UserService() {
        users.add(new User("admin", "admin", "ADMIN"));
        users.add(new User("user1", "pass123", "USER"));
    }


    public User validateUser(String username, String password) {
        for (User user : users) {
            log.info("User Name: {}, User Password: {}", username, password);
            if (user.getUsername().equals(username) && user.getPassword().equals(password)) {
                log.info("User found");
                return user; // Valid user found
            }
        }
        return null;
    }
}
