   M S B A M L   `   `   `  ����  ClienteConsultasMedicas8    2ClienteConsultasMedicas.Views.VentanaRecepcionista   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Módulo Recepcionista��5   	   $	��450��6&   $	��800��63    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5	   
   �� 5
      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ txtBannerOffline��5      $-��'Estás trabajando en modo sin conexión��5      ���#FFF4D3
���  ��$
��Bold"�5       �� Padding$ 10q�5      $y�	Collapsed=�5      $��Stretch=�5       �� TextAlignment$ Center=�5      � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $	��200 �6#   �� 5      $��* �6#   .+�5      �� ���	#FF2C3E50$��0��60   .+�5      �� $��Recepcionista��6   $��20(�61   
�������$��Center=�5       $��10q�69   �� 5!      -   5         ��Name$ btnPacientes��5!      $��Registrar paciente��6/   $��10q�6g   $��40��6s   �� 5"      -   5        $ btnCitas��5"      $��Registrar cita��6+   $��10q�6[   $��40��6g   �� 5#      -   5        $ btnVerPacientes��5#      $��Ver pacientes��62   $��10q�6h   $��40��6t   �� 5$      -   5        $ btnVerCitas��5$      $��	Ver citas��6.   $��10q�6\   $��40��6h   �� 5%      -   5        $ btnDashboard��5%      $��Resumen��6/   $��40��6A   $��5q�6M   $	��180��6s   �� 5&      -   5        $ btnSincronizar��5&      $��Sincronizar ahora��5'   	   $��40��5)   	   $
��10,0q�5*   	   ���#3498db
�������$
��Bold"�5-   	   �� 5.      -	   5        $ lblPendientes��5.      $�� ��5/      
�������$��Italic$�51      $��
10,5,10,10q�52      $y�	Collapsed=�53      �� 55      -
   5        $ btnCerrarSesion��55      $��Cerrar sesión��62   $��10q�6h   $��40��6t   56      �� 58      -   5         ��Name$ 	contenido��58      $��1��60   $��10q�6@   59      5:      5;      