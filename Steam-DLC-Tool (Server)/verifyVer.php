<?php
$verifyVer = $_POST['verifyVer'];
$fopen = fopen("SteamDLCTool/Version.youhavetocrackthisfile", "r");
$version = file_get_contents("SteamDLCTool/Version.youhavetocrackthisfile");
fclose($fopen);
if ($verifyVer == $version) {
    echo "True";
} else {
    echo "False";
}
?>