using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyLibrary.Backend.API.DB;
using MyLibrary.Backend.API.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyLibraryDB>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"));
});
builder.Services.AddCors(Options =>
{
    Options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();

    });
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<LibraryUser>(Options =>
{
    Options.Password.RequireDigit = false;
    Options.Password.RequireLowercase = false;
    Options.Password.RequireUppercase = false;
})
    .AddEntityFrameworkStores<MyLibraryDB>();
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapIdentityApi<LibraryUser>();
app.MapPost("/books/add", (MyLibraryDB db, Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
});
app.MapGet("/books/list", (MyLibraryDB db) =>
{
    return db.Books.ToList();
});
app.MapPost("/books/update", (MyLibraryDB db, Book book) =>
{
    db.Books.Update(book);
    db.SaveChanges();
});
app.MapPost("/books/remove/{BookId}", (MyLibraryDB db, int BookId) =>
{
    var book = db.Books.Find(BookId);
    if (book != null)
    {

        db.Books.Remove(book);
        db.SaveChanges();
    }
});
app.MapPost("/members/add", (MyLibraryDB db, Member member) =>
{
    db.Members.Add(member);
    db.SaveChanges();
});
app.MapGet("/members/list", (MyLibraryDB db) =>
{

    return db.Members.ToList();
});
app.MapPost("/members/update", (MyLibraryDB db, Member member) =>
{
    db.Members.Update(member);
    db.SaveChanges();
});
app.MapPost("/members/remove/{MemberId}", (MyLibraryDB db, int MemberId) =>
{
    var member = db.Members.Find(MemberId);
    if (member != null)
    {

        db.Members.Remove(member);
        db.SaveChanges();
    }
});
app.MapPost("/borrows/add", (MyLibraryDB db, Borrow borrow) =>
{
    db.Borrows.Add(borrow);
    db.SaveChanges();
});
app.MapGet("/borrows/list", (MyLibraryDB db) =>
{

    return db.Borrows.Include(m => m.Book).Include(m => m.Member).ToList();
});
app.MapPost("/borrows/update", (MyLibraryDB db, Borrow borrow) =>
{
    db.Borrows.Update(borrow);
    db.SaveChanges();
});
app.MapPost("/borrow/remove/{BorrowId}", (MyLibraryDB db, int BorrowId) =>
{
    var borrow = db.Borrows.Find(BorrowId);
    if (borrow != null)
    {

        db.Borrows.Remove(borrow);
        db.SaveChanges();
    }
});
app.Run();

