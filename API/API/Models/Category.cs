﻿namespace API.Models;

public class Category
{
    private int _id;
    private string _name = string.Empty;
    
    public int Id { get => _id; set => _id = value; }
    public string Name { get => _name; set => _name = value; }

    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
}