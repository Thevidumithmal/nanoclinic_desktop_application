   M S B A M L   `   `   `  ????F  BNanoClinicc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DriveStorage.customcontrolsDriveStorage.customcontrols  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   G4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   
   'clr-namespace:NanoClinic
NanoClinic  5	   	   #    NanoClinic.form_PatientHealth   5   	   <customcontrols)clr-namespace:DriveStorage.customcontrols  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   
   >Wpf4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   
   $localclr-namespace:NanoClinic  5	   	   -   5          ? Title$  form_PatientHealth??5   	   $	??800??6$   $
??1438??61    ? WindowStartupLocation$ CenterScreen=?5   	   
??????  ? AllowsTransparency .  ? WindowStyle$
 None=?5   	    ? 
ResizeMode$ NoResize=?6    ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $ /resources/icons.xaml??6%   ?? 5      $e _pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml??6%   ?? 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Defaults.xaml??6%   ?? 5      $t npack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Primary/MaterialDesignColor.Blue.xaml??6%   ?? 5      $s mpack://application:,,,/MaterialDesignColors;component/Themes/Recommended/Accent/MaterialDesignColor.Lime.xaml??6%   %    5      .??5      ??  ?? CornerRadius$ 20??6   
???????._?5   
   ? 	 ? ColumnDefinitions	 5!      ?? 5"      $	??228 ?6#   ?? 5#      $??* ?6#   ?? 5$      $	??323 ?6#   .+?5'      ? .+?5(      ?? 
 ?? Orientation$
 Vertical=?6   $??0,83,0,0q?64   .+?5)      ?? $??nanoClinic.??6    $??65,0,0,0q?63   ???#337ab7$
??Left=?6Z   $??Center=?6u   $??21(?6?   $??Arial Rounded MT Bold)?6?   ?? 5,      $
 Vertical=?6!   $??	0,150,0,0q?68   .+?5-      ?? $
??65,0q?6$   $
??MENU??62      	TitleText#??[  6>   ,   &DriveStorage.customcontrols.MenuButton  5/      -   5          Name$ btn_general??5/   7   ,   &DriveStorage.customcontrols.MenuButton!   PreviewMouseLeftButtonDown$, &btn_general_PreviewMouseLeftButtonDown??6?   $??0,15,0,0q?6L      Padding$ 65,0,0,0q?6^     MyFilesFolder   Icon# [ 6q      Text$ General??6?      	GroupName$ 
MenuButton??6?    ? Cursor$
 Hand??6?   6?     50      -   5        $ btn_profile??50   4   $, &btn_profile_PreviewMouseLeftButtonDown??6?   $ 65,0,0,0q?6I     plus# [ 6\   $ Profile??6y   $ 
MenuButton??6?   $
 Hand??6?   6?     51      -   5        $ btn_appointment??51   4   $0 *btn_appointment_PreviewMouseLeftButtonDown??6?   $ 65,0,0,0q?6M     MyDrive# [ 6`   $ Appointments??6?   $ 
MenuButton??6?   $
 Hand??6?   6?     52      -   5        $ 
btn_health??52   4   $ 65,0,0,0q?6H     Filerequest# [ 6[   $ Health??6   $ 
MenuButton??6?   $
 Hand??6?   53      54      ? 56      $??Bottom=?6   $??Center=?62   $??0,0,0,49q?6O   	 57      ?? 58      $
??Auto ?6+   ?? 59      $??* ?6+   .+?5<      A? -   5         A?Name$ btn_profileImage??5<      $
 Hand??68   $??36??6F   $??36??6R   $
??Left=?6]   $??Bottom=?6x   ??5=      ?? 5>       ?? ImageSource$ /assets/patient.png??6)    j? Stretch$ UniformToFill=?6K   5@      ? 5A      $??1??6   $??14,0,0,0q?6+   $??76??6=    ? RowDefinitions 5B      ?? 5C      ?? 5D      .+?5F      ?? -   5         ??Name$ txt_username??5F   $   $?? ??6:     MainText#??[ 6B   ?? 5G      $??1??6$   $??Patient??61   #??[  6@   5H      5I      5K      ? 5Q      $??1??6   ???#EFF2F8.+?5R      ?? $??/assets/background.png??6   $	??600??68    J? Opacity$
 0.03Q?6E   ?? 5S      $??Health??6   $
??Left=?6*   $	??Top=?6E   $??	60,85,0,0q?6]   $??18(?6p   $??SemiBold"?6~   F? 5V      -   5         F?Name$ btn_back??5V        Left#??[ 6)   $
 Hand??6F   $??Right=?6T   $	??Top=?6p   $??101,85q?6?    ?? Stretch$ UniformToFill=?6?   $??22??6?   $??17??6?   ???#C2C3C36?   F? 5Y      -	   5        $ btn_next??5Y      $
 Hand??6)    	 Right#??[ 68   $??Right=?6V   $	??Top=?6r   $??60,85q?6?   $ UniformToFill=?6?   $??22??6?   $??17??6?   ???#C2C3C36?   ? 5[      $??Center=?6   $	??600??62   $??30,100,30,0q?6?    5\      ?? 5]      $??80 ?6(   ?? 5^      $??* ?6(   .+?5c      ? $??0??6   .+?5h      ?? $
 
Horizontal=?6)   $??Center=?6B   $??Bottom=?6_   .+?5j      ?? $
 Vertical=?6)   $
??Left=?6@   .+?5k   "   ?? $??	Diseases:??6-   $
??Left=?6>   $	??Top=?6Y   $??0,0,0,0q?6q   ???#337ab7$??14(?6?   $??SemiBold"?6?   ?? 5n   "   -
   5         ??Name$ cmb_HealthProblem??5n   f   $??0,0,30,0q?6+   
?????? $
 Hand??6W   $	??200??6?   $??12(?6?   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Please select a category??5o      $??1q?6U   $??SemiBold"?6j   ???#C2C3C3 " MaterialDesignOutlinedComboBox#??[ 5p   1   .@?5q   &   ?? $??Diabetes??63   ?? 5r   &   ?? 5s   &   $??Cholestorole??63   ?? 5t   &   ?? 5u   &   $??Blood Pressure??63   5w   #   ?? 5x   "   -   5         ??Name$ error_cmb_deases??5x   -   $
??Left=?6G   $
 
Horizontal=?6b   $	??Top=?6{   $??0,1,0,0q?6?   $	??200??6?   $??15??6?   .+?5y   &   ?? ???#ff3333$??5??6@   ?? 5{   &   -   5        $ txt_error_cmb_desese??5{   0   ???#fce5cd$	??Top=?6c   $	??195??6{   $?? ??6?   $??10(?6?   ???#ff3333 ?? Padding$
 10,0q?6?   $
??Left=?6?   5|   #   5~      ?? 5      $
 Vertical=?6)   $
??Left=?6@   $??0,0,30,0q?6[   .+?5?   "   ?? $??From:??6-   $
??Left=?6:   $	??Top=?6U   $??0,0,0,0q?6m   ???#337ab7$??14(?6?   $??SemiBold"?6?   (  "System.Windows.Controls.DatePicker  5?   "   -   5          Name$ start_date_picker??5?      $	??0,0q?6-   $??10,0,0,0q?6:   $??SemiBold"?6N      IsTodayHighlighted . $ Starting date??6?   $??Center=?6?   $
??Left=?6?   $	??200??6   $??50??6  ???#C2C3C3$??1q?6.      SelectedDateFormat$  Short=?6B  !   DisplayDateStart$! 
1922-03-20X?6]  6{  ?? 5?   "   -   5        $ error_startingdate??5?   -   $
??Left=?6I   $
 
Horizontal=?6d   $	??Top=?6}   $??0,1,0,0q?6?   $	??200??6?   $??15??6?   .+?5?   &   ?? ???#ff3333$??5??6@   ?? 5?   &   -   5        $ txt_error_starting_date??5?   0   ???#fce5cd$	??Top=?6f   $	??195??6~   $?? ??6?   $??10(?6?   ???#ff3333$
 10,0q?6?   $
??Left=?6?   5?   #   5?      ?? 5?      $
 Vertical=?6)   $??Right=?6@   .+?5?   "   ?? $	??To:??6-   $
??Left=?68   $	??Top=?6S   $??0,0,0,0q?6k   ???#337ab7$??14(?6?   $??SemiBold"?6?     5?   "   -   5        $ end_date_picker??5?   ?   $	??0,0q?6-   $??	10,0,10,0q?6:   $??SemiBold"?6O    . $ Ending date??6?   $??Center=?6?   $??Center=?6?   $	??200??6?   $??50??6  ???#C2C3C3$??1q?6-  $  Short=?6A  $! 
1922-03-20X?6\  6z  ?? 5?   "   -   5        $ error_enddate??5?   -   $
??Left=?6D   $
 
Horizontal=?6_   $	??Top=?6x   $??0,1,0,0q?6?   $	??200??6?   $??15??6?   .+?5?   &   ?? ???#ff3333$??5??6@   ?? 5?   &   -   5        $ txt_error_end_date??5?   0   ???#fce5cd$	??Top=?6a   $	??195??6y   $?? ??6?   $??10(?6?   ???#ff3333$
 10,0q?6?   $
??Left=?6?   5?   #   5?      ?? 5?      -   5        " ??Name$" 
btn_search??5?   ~   $??2q?6&   ???#c2c3c3
?????? $??10,0,15,10 q?6i   ???#c2c3c3 	 MaterialDesignFlatButton#??[	 6?   $??Arial Rounded MT Bold)?6?   +  %MaterialDesignThemes.Wpf.ShadowAssist#   ShadowDepth$# Depth4=?6?   $??Bottom=?6-  $??30??6H  $??90??6T  +  %MaterialDesignThemes.Wpf.ButtonAssist$   CornerRadius$$ 5??5?      $??16(?6F   $??Search??6T   6e   5?      5?      ? 5?      $??1??6   .+?5?      ?? $
 Vertical=?6%   $??0,25,0,0q?6<   .+?5?      ?? $
 
Horizontal=?6)   $??Center=?6B   .+?5?   "   ?? $??0,0,15,0q?6)   $ 15??6=   $	??250??6O   $	??110??6[   $
??Left=?6h   ???#BFE2FF._?5?   &   ?  5?   *   ?? 5?   .   $??30 ?6<   ?? 5?   .   $??* ?6<   .+?5?   *   ? $??0??6/   .+?5?   .   ?? $??Maximum??68   $??Arial Rounded MT Bold)?6H   $??16(?6k   ???#000$??Center=?6?   $??Center=?6?   5?   +   ? 5?   *   $??1??6/   .+?5?   .   ?? $
 
Horizontal=?69   $??Center=?6R   $??Center=?6m   $??
25,0,50,25q?6?   .+?5?   2   ?? $??/assets/Max.png??68   $??60??6Q   $
??Left=?6_   $??	50,0,10,0q?6z   ?? 5?   2   -   5        % ??Name$	% max??5?   ?   & ?? 
CaretBrush
& ?  ??' ?? 
IsReadOnly' . $??Right=?6^   $ IBeam??6|   ( ?? TextWrapping$
( Wrap=?6?   $	??150??6?   $??0q?6?   $??50??6?   $??30(?6?   $	??---??6?   $??Center=?6?   
???   ?$??SemiBold"?6   ) ?? TextAlignment$
) Left=?67  5?   /   5?   +   5?   '   5?   #   ?? 5?   "   $??0,0,15,0q?6)   $ 15??6=   $	??250??6O   $	??110??6[   $
??Left=?6h   ???#BFE2FF._?5?   &   ?  5?   *   ?? 5?   .   $??30 ?6<   ?? 5?   .   $??* ?6<   .+?5?   *   ? $??0??6/   .+?5?   .   ?? $??Minimum??68   $??Arial Rounded MT Bold)?6H   $??16(?6k   ???#000$??Center=?6?   $??Center=?6?   5?   +   ? 5?   *   $??1??6/   .+?5?   .   ?? $
 
Horizontal=?69   $??Center=?6R   $??Center=?6m   $??
25,0,50,25q?6?   .+?5?   2   ?? $??/assets/Min.png??68   $??60??6Q   $
??Left=?6_   $??	50,0,10,0q?6z   ?? 5?   2   -   5        $	% min??5?   o   
& ?  ??' . $ IBeam??6`   $
( Wrap=?6|   $	??150??6?   $??0q?6?   $??50??6?   $??30(?6?   $	??---??6?   $??Center=?6?   
???   ?$??SemiBold"?6  $
) Left=?6  5?   /   5?   +   5?   '   5?   #   ?? 5?   "   $??0,0,0,0q?6)   $ 15??6<   $	??250??6N   $	??110??6Z   $
??Left=?6g   ???#BFE2FF._?5?   &   ?  5?   *   ?? 5?   .   $??30 ?6<   ?? 5?   .   $??* ?6<   .+?5?   *   ? $??0??6/   .+?5?   .   ?? $??Average??68   $??Arial Rounded MT Bold)?6H   $??16(?6k   ???#000$??Center=?6?   $??Center=?6?   5  +   ? 5  *   $??1??6/   .+?5  .   ?? $
 
Horizontal=?69   $??Center=?6R   $??Center=?6m   $??
25,0,50,25q?6?   .+?5  2   ?? $??/assets/Avg.png??68   $??60??6Q   $
??Left=?6_   $??	50,0,10,0q?6z   ?? 5  2   -   5        $	% avg??5  o   
& ?  ??' . $ IBeam??6`   $
( Wrap=?6|   $	??150??6?   $??0q?6?   $??50??6?   $??30(?6?   $	??---??6?   $??Center=?6?   
???   ?$??SemiBold"?6  $
) Left=?6  5
  /   5  +   5  '   5  #   5     ?? 5     $??
30,30,30,0q?6*   $
 Vertical=?6>   .+?5  "   ? $	??370??6'   .+?5  "   #  LiveCharts.Wpf.CartesianChart  &   LiveCharts.Wpf.Charts.Base.Chart*   LegendLocation$	* Top=?6Y   +   Series+ 65   ?? *SeriesCollection+,   AxisX, 5   *   	  LiveCharts.Wpf.Axis	  - 	  Title$- X??63   . 	  Labels. 6=   ?? *	BarLabels+6\   /   AxisY/ 5#  *   	  $- Y??63   0 	  LabelFormatter0 6=   ?? *	Formatter+6d   5&  #   5(  #   5-     59     5;     5<     5@     ? 5C     $??2??6   .+?5D     ?? $
 Vertical=?6   $??0,62,0,0q?64   .+?5F     )
  #MaterialDesignThemes.Wpf.DialogHost
  -   5        1 
 Name$1 
DialogHost??5F  H   2 
  CloseOnClickAway2 . .??5G     '  !MaterialDesignThemes.Wpf.PopupBox  ???#337ab7$??Right=?6H   $??	0 20 20 0q?6d   3   PlacementMode$3 BottomAndAlignRightEdges=?5H     4   	StaysOpen4 .  $??25??5I     5   PopupContent.5 5J     ?? $	??125??6)   .+?5K  "   ?? -   5        $" btn_exit??5K  )   6 ? ToolTip$6 Shut down Application??6;   $??0 4 0 0q?6[   $??Exit  Application??6l   6?   ?? 5L  "   -   5        $" 
btn_logout??5L  )   $6 Logout Application??6=   $??Logout??6Z   6k   5N     5P     5Q     ?? 5T     $??Latest Health Information??6    $??21(?6A   $??SemiBold"?6O   ???#337ab7$??0,5,0,20q?6z   $??Center=?6?   ?? 5V     $??0,10,0,0q?6   $ 20??60   $	??300??6B   $	??275??6N   
?????? $??1q?6t   ???#337ab7._?5W     ?? $
 
Horizontal=?6%   $
??Left=?6>   .+?5X     ?? $
 Vertical=?6)   $
??Left=?6@   $??Center=?6[   $	??3,0q?6v   $	??155??6?   .+?5Y  "   ?  5Z  &   ?? 5[  *   $??45 ?68   ?? 5\  *   $??45 ?68   ?? 5]  *   $??45 ?68   ?? 5^  *   $??45 ?68   ?? 5_  *   $??45 ?68   ?? 5`  *   $??45 ?68   .+?5c  &   ? $??0??6+   .+?5d  *   ?? $??Height:??64   $??Center=?6C   $
??Left=?6^   $
??25,0q?6y   $??14(?6?   $??SemiBold"?6?   5e  '   ? 5f  &   $??1??6+   .+?5g  *   ?? $??Weight:??64   $??Center=?6C   $
??Left=?6^   $
??25,0q?6y   $??14(?6?   $??SemiBold"?6?   5h  '   ? 5i  &   $??2??6+   .+?5j  *   ?? $??	Diabetes:??64   $??Center=?6E   $
??Left=?6`   $
??25,0q?6{   $??14(?6?   $??SemiBold"?6?   5k  '   ? 5l  &   $??3??6+   .+?5m  *   ?? $??Cholestorole:??64   $??Center=?6I   $
??Left=?6d   $
??25,0q?6   $??14(?6?   $??SemiBold"?6?   5n  '   ? 5o  &   $??4??6+   .+?5p  *   ?? $??	Allergic:??64   $??Center=?6E   $
??Left=?6`   $
??25,0q?6{   $??14(?6?   $??SemiBold"?6?   5q  '   ? 5r  &   $??5??6+   .+?5s  *   ?? $??High B Pre:??64   $??Center=?6G   $
??Left=?6b   $
??25,0q?6}   $??14(?6?   $??SemiBold"?6?   5t  '   5y  #   5{     ?? 5|     $
 Vertical=?6)   $??Right=?6@   $	??150??6\   $??-20,0q?6h   $??Center=?6w   .+?5}  "   ?  5~  &   ?? 5  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   .+?5?  &   ? $??0??6+   .+?5?  *   ?? -   5        $% txt_patient_height??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6(  5?  '   ? 5?  &   $??1??6+   .+?5?  *   ?? -   5        $% txt_patient_weight??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6(  5?  '   ? 5?  &   $??2??6+   .+?5?  *   ?? -   5        $% txt_patient_diabetes??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6*  5?  '   ? 5?  &   $??3??6+   .+?5?  *   ?? -   5        $% txt_patient_cholestorole??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6.  5?  '   ? 5?  &   $??4??6+   .+?5?  *   ?? -   5        $% txt_patient_allergic??5?  x   $??10,0,0,0q?63   $?? ??6G   ' . $??SemiBold"?6a   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6,  5?  '   ? 5?  &   $??5??6+   .+?5?  *   ?? -   5        $% txt_patient_bloodpressure??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6/  5?  '   5?  #   5?     5?     5?     ?? 5?     $??Bottom=?6   $??0,30,0,0q?69   $ 20??6K   $	??300??6]   $	??275??6i   
?????? $??1q?6?   ???#337ab7._?5?     ?? $
 
Horizontal=?6%   $
??Left=?6>   .+?5?     ?? $
 Vertical=?6)   $
??Left=?6@   $??Center=?6[   $	??3,0q?6v   $	??155??6?   .+?5?  "   ?  5?  &   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   .+?5?  &   ? $??0??6+   .+?5?  *   ?? $??Cancer:??64   $??Center=?6C   $
??Left=?6^   $
??25,0q?6y   $??14(?6?   $??SemiBold"?6?   5?  '   ? 5?  &   $??1??6+   .+?5?  *   ?? $??Depression:??64   $??Center=?6G   $
??Left=?6b   $
??25,0q?6}   $??14(?6?   $??SemiBold"?6?   5?  '   ? 5?  &   $??2??6+   .+?5?  *   ?? $??Alcohol use:??64   $??Center=?6H   $
??Left=?6c   $
??25,0q?6~   $??14(?6?   $??SemiBold"?6?   5?  '   ? 5?  &   $??3??6+   .+?5?  *   ?? $??Smoking:??64   $??Center=?6D   $
??Left=?6_   $
??25,0q?6z   $??14(?6?   $??SemiBold"?6?   5?  '   ? 5?  &   $??4??6+   .+?5?  *   ?? $??	Drug use:??64   $??Center=?6E   $
??Left=?6`   $
??25,0q?6{   $??14(?6?   $??SemiBold"?6?   5?  '   5?  #   5?     ?? 5?     $
 Vertical=?6)   $??Right=?6@   $	??150??6\   $??-20,0q?6h   $??Center=?6w   .+?5?  "   ?  5?  &   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   ?? 5?  *   $??45 ?68   .+?5?  &   ? $??0??6+   .+?5?  *   ?? -    5        $% txt_patient_cancer??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6(  5?  '   ? 5?  &   $??1??6+   .+?5?  *   ?? -!   5        $% txt_patient_depression??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6,  5?  '   ? 5?  &   $??2??6+   .+?5?  *   ?? -"   5        $% txt_patient_alcohole??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6*  5?  '   ? 5?  &   $??3??6+   .+?5?  *   ?? -#   5        $% txt_patient_smoking??5?  v   $??10,0,0,0q?62   $?? ??6E   ' . $??SemiBold"?6_   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6)  5?  '   ? 5?  &   $??4??6+   .+?5?  *   ?? -$   5        $% txt_patient_druguse??5?  x   $??10,0,0,0q?63   $?? ??6G   ' . $??SemiBold"?6a   $??0,0,0,1q?6?   ???#C2C3C3$??12(?6?   $??30??6?   $	??120??6?   $??Center=?6?   $??Center=?6  $ IBeam??6+  5?  '   5?  #   5?     5?     5?     5?     5?     5?     5?     5?     