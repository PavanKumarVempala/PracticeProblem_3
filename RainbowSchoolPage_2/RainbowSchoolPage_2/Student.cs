using System;

class Student
{
    public string Name { get; set; }
    public string Class { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Class}";
    }
}