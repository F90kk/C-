   M S B A M L   `   `   `  ����  
LibraryApp$    LibraryApp.Views.AddBookWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Добавить книгу��5   	   $	��410��6    $	��400��6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Название:��6   �� 5   
   $��1��6   $��0,0,0,10q�6[   ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6[   �� 5   
   $��2��6   $��Автор:��6   �� 5   
   $��3��6   $��0,0,0,10q�6\   ��6   �� *Author+$ PropertyChanged=�6\   �� 5   
   $��4��6   $��Год:��6   �� 5   
   $��5��6   $��0,0,0,10q�6Z   ��6   �� *Year+$ PropertyChanged=�6Z   �� 5   
   $��6��6   $��Описание:��6   �� 5   
   $��7��6    �� AcceptsReturn$
 True��6a   $��50��6v   $��0,0,0,10q�6�   ��6   �� *Description+$ PropertyChanged=�6�   �� 5   
   $��8��6   $��Путь к файлу:��6   �� 5    
   $��9��6   $��	0,0,50,35q�6^   ��6   �� *
FilePath+$ PropertyChanged=�6^   �� 5!   
   -   5        $��9��5!      $��Обзор...��6   $��Right=�6J   $��40��6f   $��0,0,0,35q�6q   �� 5#   
   $��9��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   $��60��6V   $��	267,0,0,0q�6b   $��Bottom=�6u   .+�5$      �� $��Добавить��6   $��	0,40,10,0q�6G   ��6(   �� *
AddCommand+6G   �� 5%      $��Отмена��6   $��	-2,40,0,0q�6H   ��6&   �� *CancelCommand+6H   5&      5'      5(      