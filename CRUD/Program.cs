using CRUD.Model;
using CRUD.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();
app.MapGet("/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.MoneyOperations.ToListAsync();
});

app.MapPost("/add", async (HttpContext context, ApplicationDbContext db) =>
{
    MoneyOperation? operation = await context.Request.ReadFromJsonAsync<MoneyOperation>();

    if(operation!=null)
    {
        db.MoneyOperations.Add(operation);
        db.SaveChanges();
    }

    return operation;
});

app.MapGet("/get",(HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if(int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value,out id))
    {
        return db.MoneyOperations.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/update", async (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        MoneyOperation? operation = await context.Request.ReadFromJsonAsync<MoneyOperation>();

        if (operation != null)
        {
            operation.Id = id;
            db.MoneyOperations.Update(operation);
            db.SaveChanges();
        }
        return db.MoneyOperations.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/delete", (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        db.MoneyOperations.Remove(db.MoneyOperations.Where(op=>op.Id==id).First());
        db.SaveChanges();
    }
});

//Operation Table


app.MapGet("/operation/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Operations.ToListAsync();
});
app.MapPost("/operation/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Operation? operation = await context.Request.ReadFromJsonAsync<Operation>();

    if (operation != null)
    {
        db.Operations.Add(operation);
        db.SaveChanges();
    }

    return operation;
});

app.MapGet("/operation/get", (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        return db.Operations.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/operation/update", async (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        Operation? operation = await context.Request.ReadFromJsonAsync<Operation>();

        if (operation != null)
        {
            operation.Id = id;
            db.Operations.Update(operation);
            db.SaveChanges();
        }
        return db.Operations.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/operation/delete", (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        db.Operations.Remove(db.Operations.Where(op => op.Id == id).First());
        db.SaveChanges();
    }
});




//Company Table


app.MapGet("/company/all", async (HttpContext context, ApplicationDbContext db) =>
{
    return await db.Companies.ToListAsync();
});
app.MapPost("/company/add", async (HttpContext context, ApplicationDbContext db) =>
{
    Company? company = await context.Request.ReadFromJsonAsync<Company>();

    if (company != null)
    {
        db.Companies.Add(company);
        db.SaveChanges();
    }

    return company;
});

app.MapGet("/company/get", (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        return db.Companies.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/company/update", async (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        Company? company = await context.Request.ReadFromJsonAsync<Company>();

        if (company != null)
        {
            company.Id = id;
            db.Companies.Update(company);
            db.SaveChanges();
        }
        return db.Companies.Where(op => op.Id == id);
    }
    return null;
});


app.MapPost("/company/delete", (HttpContext context, ApplicationDbContext db) =>
{
    int id;
    if (int.TryParse(context.Request.Query.Where(x => x.Key == "id").FirstOrDefault().Value, out id))
    {
        db.Companies.Remove(db.Companies.Where(op => op.Id == id).First());
        db.SaveChanges();
    }
});


app.Run();
