   M S B A M L   `   `   `  ����M  IRestauranteApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:RestauranteApp.WPF.ViewModelsRestauranteApp.WPF.ViewModels  5      (    "RestauranteApp.WPF.Views.OrdenView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      :vm+clr-namespace:RestauranteApp.WPF.ViewModels     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5
      � $��20q�6     � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��Resumen de Orden��6   $��20(�6,   $
��Bold"�6:   $��0,0,0,10q�6L   �� 5   
   $��1��6   $��0,0,0,10q�5      $
��Auto=�5      ��5      �� *
Detalles+��5      �� 5      .R�5      � $	��0,5q�6    � ColumnDefinitions 5      �� 5      $��* �6/   �� 5      $
��Auto �6/   .+�5       �� $
��Wrap=�5!      $��14(�5"      $��0��5#      $��0,0,10,0q�5$      ��5    $   �� *DescripcionCompleta+5$      �� 5'      $��Eliminar��6!   $��1��5(      $��80��5+      ��5)      �� *!DataContext.EliminarItemCommand+ �� RelativeSource ��  �� AncestorType UserControl��5*      �� 5+      5,      5-      5/      �� 52   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,10,0,0q�6W   .+�53      �� $
��Bold"�54      $��Center=�55      $��0,0,10,0q�56      ��53      �� *Total+ �� StringFormat$ Total: ${0:F2}��56      �� 57      $��Vaciar Orden��6   $��0,0,10,0q�6S   ��6,   �� *VaciarOrdenCommand+6S   �� 58      $��Agregar Más��6   $��0,0,10,0q�6P   ��6+   �� *ContinuarCommand+6P   �� 59      $��	Finalizar��6   ��6)   �� *FinalizarCommand+5:      5;      5<      