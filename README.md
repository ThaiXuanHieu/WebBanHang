# WebBanHang

## Install
1. Open file WebBanHang.sln
2. Right click the project WebBanHang.Data, choose Set as StartUp Project
3. Change ConnectionString(data source and user) in 2 file App.Config in project WebBanHang.Data and Web.config in project WebBanHang.Web
```
<connectionStrings>
  <add name="WebBanHangDbContext" connectionString="data source=DESKTOP-*******;initial catalog=WebBanHang;persist security info=True;user id=sa;password=******;MultipleActiveResultSets=True;App=EntityFramework" providerName="System.Data.SqlClient" />
</connectionStrings>
```
4. Choose Tools -> NuGet Package Manager -> Package Manager Console
5. Select Default Project become WebBanHang.Data
6. Type ``` Update-Database``` and press Enter
7. Press F5 to Run

## Pages
