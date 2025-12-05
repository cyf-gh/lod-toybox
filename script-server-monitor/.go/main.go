package main

import (
	"./monitor"
	"fmt"
	"net/http"
)

func main() {
	http.HandleFunc("/monitor/ports", monitor.MonitorHandler)
	fmt.Println("Started server on :8888" )
	http.ListenAndServe(":8888", nil)
}