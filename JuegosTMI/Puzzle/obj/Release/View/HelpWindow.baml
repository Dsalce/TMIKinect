   M S B A M L   `   `   `  ���� 
  Puzzle    puzzle.View.HelpWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35_ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   -     � Title$  
HelpWindow��$
��1000��$
��1060��
 � Top$ 0�� � Left$	 200�� � WindowState$ 	Maximized=�.��4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  -     Name$ kinectRegion��.��� ���	#FF157D87 � RowDefinitions �� $
��122* ��� $
��438* ��� $
��109* � � ColumnDefinitions �� .+�4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  -   $��sensorChooserUi��$��Center=�$��369,19,373,55q�$	��310��$��0��8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   $	��122��$	��174�����	#FF157D87$	��Top=�$��Right=�$��	878,0,0,0q�.���� $
��Auto��$
��Auto��$
��Fill=�$)��#imagenes/imageSelectPuzzle/exit.png��  -   $	��122��$	��174�����	#FF157D87$	��Top=�$��Right=�$��	0,0,174,0q�.���� $
��Auto��$
��Auto��$
��Fill=�$+��%imagenes/imageSelectPuzzle/expand.png��r� -   $��videoControl�� r� Source$# View/VideoHelp/helpPuzzle.mp4?�$y�Visible=� r� Volume$ 4Q�$��1��$��0q�	 r� Position$	 0:0:3h�
 J� IsHitTestVisible
 . |�.  r� LoadedBehavior$ Manual=��� $��Center=� �� Orientation$ 
Horizontal=�$��Bottom=�$��80��$��221,0,227,25q�$	��604��$��2��.+�  -   $��BtPlay��$
��PLAY��$
��Auto��
���   ����	#FF3E8F31$��0,0,0,10q�$	��200��  -     Name$ BtPause��$��PAUSE��$
��Auto�����	#FF040404���	#FF3E8F31$��0,0,0,10q�$	��200��  -	   $ BtStop��$
��STOP��$
��Auto��
���   ����	#FF3E8F31$��0,0,0,10q�$	��200��