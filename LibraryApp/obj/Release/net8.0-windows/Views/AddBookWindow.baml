   M S B A M L   `   `   `  ����   
LibraryApp$    LibraryApp.Views.AddBookWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$!  Добавить книгу��$	��410��$	��400��.��� $��10q� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��Название:���� $��1��$��0,0,0,10q����� *Title+ �� UpdateSourceTrigger$ PropertyChanged=��� $��2��$��Автор:���� $��3��$��0,0,0,10q����� *Author+$ PropertyChanged=��� $��4��$��Год:���� $��5��$��0,0,0,10q����� *Year+$ PropertyChanged=��� $��6��$��Описание:���� $��7�� �� AcceptsReturn$
 True��$��50��$��0,0,0,10q����� *Description+$ PropertyChanged=��� $��8��$��Путь к файлу:���� $��9��$��	0,0,50,35q����� *
FilePath+$ PropertyChanged=��� -   $��9��$��Обзор...��$��Right=�$��40��$��0,0,0,35q��� $��9�� �� Orientation$ 
Horizontal=�$
��Left=�$��60��$��	267,0,0,0q�$��Bottom=�.+��� $��Добавить��$��	0,40,10,0q����� *
AddCommand+�� $��Отмена��$��	-2,40,0,0q����� *CancelCommand+