   M S B A M L   `   `   `  ����  
LibraryApp    LibraryApp.AddBookWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$!  Добавить книгу��5   	   $	��300��6    $	��400��6-   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Название:��6   �� 5   
   $��1��6   $��0,0,0,10q�6[   ��6   �� *Title+ �� UpdateSourceTrigger$ PropertyChanged=�6[   �� 5   
   $��2��6   $��Автор:��6   �� 5   
   $��3��6   $��0,0,0,10q�6\   ��6   �� *Author+$ PropertyChanged=�6\   �� 5   
   $��4��6   $��Год:��6   �� 5   
   $��5��6   $��0,0,0,10q�6Z   ��6   �� *Year+$ PropertyChanged=�6Z   �� 5   
   $��6��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� $��Добавить��6   $	��100��6G   $��0,0,10,0q�6S   ��6(   �� *
AddCommand+6S   �� 5      $��Отмена��6   $	��100��6H   ��6&   �� *CancelCommand+6H   5      5      5      