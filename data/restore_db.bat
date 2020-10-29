set mysql="C:\Program Files\MySQL\MySQL Server 8.0\bin\mysql"
set password=admin
%mysql% -u root --password=%password% istoredb < scripts\IStore_Scheme.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_categories.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_roles.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_default_users.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_suppliers.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_products.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_supplier_products.sql
%mysql% -u root --password=%password% istoredb < scripts\fill_aes_settings.sql
pause