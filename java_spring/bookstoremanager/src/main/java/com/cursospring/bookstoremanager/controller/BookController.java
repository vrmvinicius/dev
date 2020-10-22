package com.cursospring.bookstoremanager.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController //Indica que o controller terá suporte a REST. Retornando conteúdo JSon e afins.
@RequestMapping("/api/v1/books") //Suporte para acesso via browser.
public class BookController {

    @GetMapping
    public String Hello(){
        return "Hello Bookstore Manager";
    }
}
