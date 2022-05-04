import base64
from dataclasses import replace
import time

#FOGMOE-2022/03/27-Sawe25asg@
def ChangeKeyDate():
    with open("Steam-DLC-Tool (Server)\SteamDLCTool\KeyToday.youhavetocrackthisfile","r",encoding = "utf-8") as file:
        oldKey = base64.b64decode(file.read()).decode("utf-8")
        file.close()
    with open("Steam-DLC-Tool (Server)\SteamDLCTool\KeyToday.youhavetocrackthisfile","w",encoding = "utf-8") as file:    
        date = time.strftime("%Y/%m/%d", time.localtime())
        oldDate = oldKey[7:17]
        newKey = oldKey.replace(oldDate,date).encode("utf-8")
        newContent = str(base64.b64encode(newKey),'UTF-8')
        file.write(newContent)
        file.close()

while True:
    timeNow = time.strftime("%H", time.localtime())  
    if timeNow == "00": 
        print("AutoKeyUpdate : Done")
        ChangeKeyDate()
        time.sleep(3600)      
    time.sleep(900)         


