   M S B A M L   `   `   `  ����E  ALibraryApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:LibraryApp
LibraryApp  5   	       LibraryApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   *localclr-namespace:LibraryApp     5   	     � Title$1  +Электронная библиотека��5   	   $	��450��6(   $	��800��65    � 	Resources 5         TakeButtonTemplate �� 
TargetType �� CornerRadius �� Padding �� Orientation��%�   &	        �� 5   
   " ��65   .R�5      �� ���#4CAF50$ 5��6*   $ 5q�6;   ._�5	      �� $ 
Horizontal=�6   .+�5
      �� $��📚 ��6    $��16(�6+   �� 5      $��Center=�6'   5      5      5      5      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0,0,0,10q�6"   .+�5      �� "   LibraryApp.PlaceholderHelper   PlaceholderText$! Название книги��6   $��0,0,0,5q�5      ��5      �� *
NewTitle+ �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $ 
Автор��6   $��0,0,0,5q�5      ��5      �� *	NewAuthor+$ PropertyChanged=�5      �� 5       -   5        $!��Добавить книгу��5       $��0,0,0,5q�5"      5#      �� 5&   
   $��1��6   $" Поиск по автору��5'      $��0,0,0,10q�5)      ��5(      �� *SearchAuthor+$ PropertyChanged=�5)      �� 5,   
   $��2��6   ��6   �� *BooksViewSource.View+��5-      �� 5.      .R�5/      � $	��0,5q�6   	 � ColumnDefinitions	 50      �� 51      $��* �6/   �� 52      $
��Auto �6/   .+�55      �� .+�56      �� $
��Bold"�6?   ��6(   �� *Title+6?   �� 57      ��6(   �� *Author+�� 58      ��6(   �� *IsAvailable+  BooleanToStringConverter
 �� 	Converter#
 [  �� ConverterParameter$$ В наличии|Занята��5;      �� 5=      -   5        $��1��5=   !   #��[  5A   !   $��10,0,0,0q�5C   !   ��5>   !   �� *IsAvailable+#
 [ $ Взять|Вернуть��5C   !   5D      5E      5G      5H      5I      