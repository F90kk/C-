   M S B A M L   `   `   `  ����  
LibraryApp    LibraryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$1  +Электронная библиотека��5   	   $	��450��6(   $	��800��65   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6   $��5q�6"   .+�5      �� -   5         ��Name$ SearchTextBox��5      $��0,0,0,5q�5      ��5      �� *SearchQuery+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $!��Добавить книгу��6   ��6.   �� *AddBookCommand+5      �� 5   
   $��1��6   $��5q�6>   ��6    �� *Books+ �� View 5      �� 5      .P�5      �� $��Название��6%    �� DisplayMemberBinding 67   �� *Title+�� 5      $��
Автор��6%    64   �� *Author+�� 5      $��Год��6%    62   �� *Year+�� 5      $��Прогресс��6%    67   �� *UploadProgress+ �� StringFormat$
 {0}%��5      5      � 5   
   $��2��6   $��5q�6    � ColumnDefinitions 5       �� 5!      $��* �6#   �� 5"      $
��Auto �6#   .+�5%      �� $	��100��6;   $��0,0,5,0q�6H   ��6   �� *ChatMessages+6H   �� 5&      $��1��6   .+�5'      �� $	��200��67   ��6   �� *ChatMessage+67   �� 5(      $��Отправить��6   ��6-   �� *SendMessageCommand+5)      5*      5+      5,      