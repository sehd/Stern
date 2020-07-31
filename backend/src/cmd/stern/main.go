package main

import (
	"fmt"
	"stern/logger"

	"github.com/spf13/viper"
)

func main() {
	defaultLogger := logger.DefaultLogger{}
	defaultLogger.Start(viper.Sub("Logger"))
}

func initConfig() {
	viper.SetDefault("Logger", "DefaultLogger")
	viper.SetConfigName("config")
	viper.AddConfigPath(".")
	err := viper.ReadInConfig()
	if err != nil {
		panic(fmt.Errorf("Fatal error config file: %s", err))
	}
}
