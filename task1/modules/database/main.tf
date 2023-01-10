resource "azurerm_sql_server" "sql-server" {
    name = var.kpmg_database
    resource_group_name = var.resource_group
    location = var.location
    version = var.kpmg_database_version
    administrator_login = var.kpmg_database_admin
    administrator_login_password = var.kpmg_database_password
}

resource "azurerm_sql_database" "kpmg-db" {
  name                = "kpmg-db"
  resource_group_name = var.resource_group
  location            = var.location
  server_name         = azurerm_sql_server.sql-server.name
