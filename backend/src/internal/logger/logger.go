package logger

import (
	viper "github.com/spf13/viper"
)

type DefaultLogger struct{}

func (l DefaultLogger) Start(configs *viper.Viper) {
	println("Hello")
}
