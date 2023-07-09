#nowarn "20"
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.DependencyInjection
open Giraffe

let webApp =
    choose [
        route "/ping" >=> text "pong";
        route "/" >=> htmlFile "/pages/index.html"
    ]

let builder = WebApplication.CreateBuilder()

let app = builder.Build()

app.UseGiraffe webApp

app.RunAsync() |> Async.AwaitTask |> Async.RunSynchronously

