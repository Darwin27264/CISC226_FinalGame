extends CanvasLayer

onready var camera = $Camera2D
onready var audio = $AudioStreamPlayer
onready var animation = $AnimationPlayer

var demigod

func init(demigod):
	self.demigod = demigod

func _ready():
	get_tree().paused = true
	camera.current = true
	audio.play()
	animation.play("Scare")

func _on_AudioStreamPlayer_finished():
	get_tree().paused = false
	demigod.game_over()
	queue_free()
