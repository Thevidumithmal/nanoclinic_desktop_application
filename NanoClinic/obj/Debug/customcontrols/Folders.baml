   M S B A M L   `   `   `  ????F  BNanoClinicc, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:DriveStorage.customcontrolsDriveStorage.customcontrols  5      )    #DriveStorage.customcontrols.Folders   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;local)clr-namespace:DriveStorage.customcontrols     5      -   5          >?Name$
  this??5        ? 	Resources 5         DefaultIcon  DefaultImage ?? 	UriSource  DropShadowPath F? Softness F? ShadowDepth F? Color F? 	Direction  
FolderIcon ?? 
TargetType ?? Property	 ?? Value
 ?? Triggers ?? Binding ?? RelativeSource ?? Mode ?? AncestorType ?? Value  ProfileImageStyle  FolderNameStyle  MenuTextStyle  FolderButtonStyle ?? 
TargetType ?? ElementName ?? FallbackValue ?? TargetNullValue  	TitleText ?? Orientation j? Stretch ?? ImageSource ?? Triggers??%N  &	        &	 ?    &	 ?    &	 G    7  &	 ?    &	 ,    &	 <    &	 ?	    7  7   7   7  7  7  B? 5   
   $????M4,2L4,22 12.683594,22C12.387594,21.378,12.181078,20.707,12.080078,20L12.074219,20C12.026219,19.673 12,19.34 12,19 12,15.474 14.609,12.566078 18,12.080078 18.327,12.033078 18.66,12 19,12 19.34,12 19.673,12.033078 20,12.080078L20,8 14,2 4,2z M13,3.4550781L18.5,9 13,9 13,3.4550781z M19,14C16.25,14 14,16.25 14,19 14,21.75 16.25,24 19,24 21.75,24 24,21.75 24,19 24,16.25 21.75,14 19,14z M19,16C19.461147,16,19.892436,16.114019,20.283203,16.300781L16.300781,20.285156C16.113553,19.893994 16,19.461758 16,19 16,17.346 17.346,16 19,16z M21.699219,17.716797C21.885981,18.107564 22,18.538853 22,19 22,20.654 20.654,22 19,22 18.538242,22 18.106006,21.886447 17.714844,21.699219L21.699219,17.716797zC?6+   ?? 5   
   $ /assets/Profile.jpg??6,   F? 5   
   $ 2Q?68   $ 5Q?6E   $ 	LightGray??6U   $	 320Q?6g   ?? 5   
   " F?6#   .?5      ??  ?@J?BitmapEffect8	   6-   ?? 5       ? ??$	 Stretch=?64   ?? 5       ? ??$	 Stretch=?62   ?? 5       ?@??Stretch$
	 Fill=?6(   ?? 5       ? ??
	 ?????6%   
 5      ?? 5       6   ?? *IsMouseOver+ ?? $ FindAncestor=?$ ToggleButtonL? True6?   .a?5      ??  ? ??	 ?#337ab76-   5       ?? 5!       6   ?? *	IsChecked+ ?? $ FindAncestor=?$ ToggleButtonL? True6?   .a?5"      ??  ? ??	 ?#337ab76-   5#      5%      ?? 5)   
   " A?6*   .?5*      ??  ? ??$		 120??6'   ?? 5+       ? ??$		 120??6&   ?? 5,       ?@??Stretch$	 UniformToFill=?6(   5-      ?? 51   
   " ??6(   .?52      ??  ? ??
	 ?   ?6+   ?? 53       ? ??$
	 Left=?64   ?? 54       ? ??$	 Bottom=?62   ?? 55       ? ??$	 16(?6)   ?? 56       ? ??$	 SemiBold"?6+   ?? 57       ? ??$	 SemiBold"?6+   58      ?? 5<   
   " ??6&   .?5>      ??  ? ??
	 ?   ?6+   ?? 5?       ? ??$	 Center=?62   ?? 5@       ? ??$	 12(?6)   ?? 5A       ? ??$	 Normal"?6+   ?? 5B       ? ??$	 Segoe UI Semibold)?6+   ?? 5C       ? ??$	 11,0,0,0q?6'   
 5G      ?? 5H       6   ?? *IsMouseOver+ ?? $ FindAncestor=?$ ToggleButtonL? True6?   .a?5I      ??  ? ??	 ?#515EC163   5J      ?? 5K       6   ?? *	IsChecked+ ?? $ FindAncestor=?$ ToggleButtonL? True6?   .a?5L      ??  ? ??	 ?#515EC163   5M      5P      ?? 5U   
   " d?6*   .?5V      ??  ? ??$		 201??6'   ?? 5W       ? ??$		 230??6&   ?? 5X       ? ??$	 Center=?6;   ?? 5Y       ? ??$	 Center=?62   ?? 5Z       ? ??
	 ???? 6+   ?? 5[       ? ??$	 0q?60   ?? 5\       ? ??$	 10(?6)   ?? 5]       ? ??$
	 Bold"?6+   ?? 5^       ? |?	 .  6*   ?? 5_       ? ??	 5`      ?? 5a      " d?6&   .R?5b      ?? #??z??6!   ._?5c      ? $??Stretch=?6#   $??Stretch=?6A   .+?5f   "   F? 8??  ??6'   ?? *
FolderIcon+$
 this??8  8  6?   ?? 5i   "   8?? $??30,75,30.4,0q?6?   $	??Top=?6?   $??12(?6?   $??96??6?   ??6P   ?? *
FolderInfo+$
 this??$ 
FolderInfo??$ 
FolderInfo??6?   ?? 5l   "   $ 
Horizontal=?6-   $??28,12q?6F   $??Center=?6U   $??Center=?6r   .+?5m   &   A? 8?? ??5n   *   ?? 5o   .   $ UniformToFill=?69    6Q   ?? *ProfileImage+$
 this??$ ProfileImage??$ ProfileImage??5q   '   5s   #   ?? 5u   "   $??Center=?6?   $??Bottom=?6?   $
??28,8q?6?   8?? ??6,   ?? *
FolderName+$
 this??$ 
FolderName??$ 
FolderName??6?   5v      5w       5x      ?? 5z      $
 True??6[    6*   ?? *
IsSelected+$
 this??.a?5{   "   ??  ?@d?	IsChecked$
	 TrueY?6>   5|      5~      5?      5?      5?      .??5?      	? #??[ 6    	? 	GroupName 6=   ?? *	GroupName+$
 this??5?      