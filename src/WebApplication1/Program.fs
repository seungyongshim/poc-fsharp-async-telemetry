open Microsoft.AspNetCore.Http


#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe

let webApp =
    choose [
        route "/ping" >=> text "pong"
    ]

let builder = WebApplication.CreateBuilder()

let app = builder.Build()

app.UseGiraffe webApp

app.MapGet("/", fun (http: HttpContext) -> task {
    return "Hello World"
})

app.RunAsync() |> Async.AwaitTask |> Async.RunSynchronously

