package com.cursospring.bookstoremanager.controller;

import io.swagger.annotations.ApiOperation;
import io.swagger.annotations.ApiResponse;
import io.swagger.annotations.ApiResponses;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController //Indica que o controller terá suporte a REST. Retornando conteúdo JSon e afins.
@RequestMapping("/api/v1/books") //Suporte para acesso via browser.
public class BookController {

    @ApiOperation("Return an example Hello World") //Swagger
    @ApiResponses(value = {
            @ApiResponse(code = 200, message = "Success method return") //Swagger
    })
    @GetMapping
    public String Hello(){
        return "Hello Bookstore Manager";
    }
}
