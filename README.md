# Generate Entity Framework Objects From Postgresql

What does it mean:

 * Run the project.
 * Write table name which you want to create object.
 * Hit the button.
 * This project generates entity framework sample object from postgresql.


Im created this project for my own. I used that for my job.

And here's some code! :+1:

```cs
if (clName.Contains("created") || clName.Contains("modified") || clName.Contains("created_by")
    || clName.Contains("modified_by") || clName.Contains("gid"))
    continue;
```

[This Lines](https://github.com/atakansavas/Generate-Entity-Framework-Objects-From-Postgis/blob/master/Form1.cs) skip that columns. Cause that columns are already in base object.

```cs
if (udtName.Contains("int"))
    tx += "int ";
else if (udtName.Contains("numeric"))
    tx += "decimal ";
else if (udtName.Contains("varchar") || udtName.Contains("text"))
    tx += "string ";
else if (udtName.Contains("timestamp"))
    tx += "DateTime ";
else if (udtName.Contains("bool") || udtName.Contains("bit"))
    tx += "bool ";
```

[This Lines](https://github.com/atakansavas/Generate-Entity-Framework-Objects-From-Postgis/blob/master/Form1.cs) sets variable type same with database.

