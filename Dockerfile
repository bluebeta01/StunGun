FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /
COPY . .
EXPOSE 9988/udp
CMD ["./StunGun", "server", "0.0.0.0", "9988"]