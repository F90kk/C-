   M S B A M L   `   `   `  ����   
LibraryApp"    LibraryApp.Views.LoginWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Авторизация��$	��200��$	��300��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0,0,0,10q�.+��� $&�� Имя пользователя:���� -    ��Name$ UsernameTextBox������ *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� $��1��$��0,0,0,10q�.+��� $��Пароль:��G� -    G�Name$ PasswordBox���� $��2�� �� Orientation$ 
Horizontal=�$��Right=�.+��� $��
Войти��$��80��$��	0,10,10,0q����� *LoginCommand+�� $��Отмена��$��80��$��0,10,0,0q����� *CancelCommand+