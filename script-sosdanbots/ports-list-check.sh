###
# @Date: 2020-11-11 21:29:50
 # @LastEditors: cyf
 # @LastEditTime: 2020-11-11 23:39:50
 # @FilePath: \undefinedz:\home\cyf\SOSDanBots\ports-list-check.sh
# @Description: What is mind? No matter. What is matter? Nevermind.
###
cd /home/cyf/SOSDanBots

rm muu_port_check.txt

index=0
addr=""
op=""

for server in `cat ports-list.txt`
do
	if [ $index == 0 ]
	then
		addr=$server
		op=$op$server
		index=$index+1
		echo 0 $addr
		continue
	else
		addr=$addr" "$server
		op=$op":"$server
		index=0
		echo 1 $addr
		nc -z -w 10 $addr
		if [ $? -eq 0 ]
		then
			op=$op"\nポート開放は異常なし。"
		else
			op=$op"\n異常があります、繋がらないんです。"
		fi
		addr=""
	fi
done
op=$op"\n報告完了。"

echo $op >> muu_port_check.txt

curl --silent 'https://qyapi.weixin.qq.com/cgi-bin/webhook/send?key=064f9e53-0faa-4b78-9c78-1db6e17376b0' \
        -H 'Content-Type: application/json' \
		-d '{
	"msgtype": "text",
	"text": {
		"content": "'$op'",
		"mentioned_list":\["@cyf"\]
	}
}'