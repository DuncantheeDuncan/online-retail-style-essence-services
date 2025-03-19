package com.pdm.userservice.util;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

class JwtUtilTest {


    @Test
    public void testExtractUsername_withMockedJwtUtil() {
        // Mock the JwtUtil class
        JwtUtil mockedJwtUtil = mock(JwtUtil.class);

        // Mock the behavior of extractUsername method
        when(mockedJwtUtil.extractUsername("mocked.token")).thenReturn("mockedUser");

        // Perform the test
        String username = mockedJwtUtil.extractUsername("mocked.token");

        // Assert that the expected value is returned
        assertEquals("mockedUser", username);
    }

    @Test
    public void testExtractRole_withMockedJwtUtil() {
        // Mock the JwtUtil class
        JwtUtil mockedJwtUtil = mock(JwtUtil.class);

        // Mock the behavior of extractRole method
        when(mockedJwtUtil.extractRole("mocked.token")).thenReturn("ADMIN");

        // Perform the test
        String role = mockedJwtUtil.extractRole("mocked.token");

        // Assert that the expected value is returned
        assertEquals("ADMIN", role);
    }
}