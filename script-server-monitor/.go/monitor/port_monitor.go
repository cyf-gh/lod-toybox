package monitor

import (
	"bytes"
	"compress/gzip"
	"encoding/json"
	"github.com/PuerkitoBio/goquery"
	"io"
	"io/ioutil"
	"net/http"
	"strconv"
	"strings"
)

type PortDescription struct {
	Port        int		`json:"port"`
	Description string  `json:"desc"`
	Accessible  bool
}

func GetPorts() [] PortDescription {
	var ports [] PortDescription
	raw, _ :=  ioutil.ReadFile( "./PortInfo.json" )
	_ = json.Unmarshal( raw, &ports )
	return ports
}

// "lod.f3322.net"
func PostJsonsDotCn( url string, ports []PortDescription ) string {
	strPort := ""
	for  _, p := range ports {
		strPort += strconv.Itoa( p.Port ) + "%2C"
	}
	body := "txt_url=" + url + "&" + "txt_port=" + strPort

	req, _ := http.NewRequest( "POST", "http://www.jsons.cn/port/", bytes.NewBufferString(body) )
	req.Header.Set("Host", "www.jsons.cn" )
	req.Header.Set("Origin", "max-age=0" )
	req.Header.Set("Cache-Control", "http://www.jsons.cn" )
	req.Header.Set("Connection", "keep-alive" )
	req.Header.Set("DNT", "1" )
	req.Header.Set("Content-Type", "application/x-www-form-urlencoded" )
	req.Header.Set("User-Agent", " Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36" )
	req.Header.Set("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9" )
	req.Header.Set("Referer", "http://www.jsons.cn/port/" )
	req.Header.Set("Accept-Encoding", "gzip, deflate" )
	req.Header.Set("Accept-Language", "en-US,en;q=0.9,zh-CN;q=0.8,zh;q=0.7,ja;q=0.6" )

	client := &http.Client{}
	resp, _ := client.Do( req )
	// respBody, _ := ioutil.ReadAll( resp.Body )
	// fmt.Println(  )
	html := DecodeGzip( resp )
	doc, _ := goquery.NewDocumentFromReader(strings.NewReader(html))
	doc.Find("#porttb > table > tbody > tr:nth-child(1) > th:nth-child(2)").SetAttr("width","50%")
	text, _ := doc.Find("#porttb").Eq(0).Html()

	for  _, p := range ports {
		text = strings.Replace( text, strconv.Itoa(p.Port), strconv.Itoa(p.Port) + "\t==>\t" + p.Description, -1 )
	}
	return text + "<hr>Powered by <a href=\"http://www.jsons.cn/port/\">Jsons.cn</a>"
}

func MonitorHandler(w http.ResponseWriter, r *http.Request) {
	w.Header().Set("Content-Type", "text/html; charset=utf-8")
	w.Write([]byte(PostJsonsDotCn("lod.f3322.net", GetPorts())))
}

func DecodeGzip( resp* http.Response ) string {
	var reader io.ReadCloser
	var err error
	if resp.Header.Get("Content-Encoding") == "gzip" {
		reader, err = gzip.NewReader(resp.Body)
		if err != nil {
			return ""
		}
	} else {
		reader = resp.Body
	}
	bt, _ := ioutil.ReadAll( reader )
	return string(bt)
}

