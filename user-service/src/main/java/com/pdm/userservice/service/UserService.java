package com.pdm.userservice.service;

import com.pdm.userservice.model.User;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class UserService {

    private List<User> users = new ArrayList<>();

    // Initialize some users
    public UserService() {
        users.add(new User("admin", "admin123", "ADMIN"));
        users.add(new User("user1", "pass123", "USER"));
    }

    //Adding users
    public User validateUser(String username, String password, String roler) {
        for (User user : users) {
            if (user.getUsername().equals(username) && user.getPassword().equals(password)) {
                return user; // Valid user found
            }
        }

        return null;
    }
}
