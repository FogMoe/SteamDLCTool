<?php 
$verifyKey = $_POST['verifyKey'];
$fopen = fopen("SteamDLCTool/KeyToday.youhavetocrackthisfile", "r");
$theKey = file_get_contents("SteamDLCTool/KeyToday.youhavetocrackthisfile");
fclose($fopen);
if ($verifyKey == $theKey) {
    echo "True";
} else {
    echo "False";
}
?>