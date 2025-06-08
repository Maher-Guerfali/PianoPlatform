using System;
using System.Linq;
using System.Text;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Text;
using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Composing;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.Standards;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;


public class MainMenu : MonoBehaviour
{
    private const string OutputDeviceName = "Microsoft GS Wavetable Synth";

    public static InputDevice inputDevice;
    public static OutputDevice _outputDevice;

    private Playback _playback;
    public ConcurrentDictionary<string, bool> concurrent = new ConcurrentDictionary<string, bool>();
    public ConcurrentDictionary<string, List<Notex>> concurrentTicks = new ConcurrentDictionary<string, List<Notex>>();
    public ConcurrentDictionary<int, int> concurrentInt = new ConcurrentDictionary<int, int>();
    public Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
    public Dictionary<int, GameObject> gobjects = new Dictionary<int, GameObject>();

    string musicString;
    MidiFile midiFile;


    public Color transparent;
    public Color pressedColor;

    string[] S;

    float t = 0.2f;
    float speed = 1f;

    bool isStopped;
    bool isBefore;

    long baseTicks;

    public GameObject gm;
    public GameObject parent;
    bool isFalling;
    bool isPlaced;

    bool goToTraining;
    bool goToFree;
    bool goToPlay;
    int currentMusic = 0;

    public GameObject pannel;
    public GameObject pannel2;
    public GameObject pannel3;
    public GameObject lines;

    /*private ConcurrentQueue<Action> callbacks = new ConcurrentQueue<Action>();

    private ConcurrentQueue<Action> callbacks2 = new ConcurrentQueue<Action>();*/

    IEnumerable<Note> notes;
    private void Start()
    {
        Screen.SetResolution(2560, 1600, true);
        //using (var inputDevicex = InputDevice.GetByName("Keystation 49"))
        {
            //this.inputDevice = inputDevicex;
            inputDevice = InputDevice.GetByName("Keystation 49");
            Debug.Log(inputDevice.Name);
            inputDevice.EventReceived += OnEventReceived;
            inputDevice.StartEventsListening();
            Debug.Log(inputDevice.IsListeningForEvents);

        }
        InitializeOutputDevice();
        //concurrent

        /*concurrent.TryAdd("A0", false);
        concurrent.TryAdd("A#0", false);
        concurrent.TryAdd("B0", false);*/
        concurrent.TryAdd("C0", false);
        concurrent.TryAdd("C#0", false);
        concurrent.TryAdd("D0", false);
        concurrent.TryAdd("D#0", false);
        concurrent.TryAdd("E0", false);
        concurrent.TryAdd("F0", false);
        concurrent.TryAdd("F#0", false);
        concurrent.TryAdd("G0", false);
        concurrent.TryAdd("G#0", false);

        concurrent.TryAdd("A1", false);
        concurrent.TryAdd("A#1", false);
        concurrent.TryAdd("B1", false);
        concurrent.TryAdd("C1", false);
        concurrent.TryAdd("C#1", false);
        concurrent.TryAdd("D1", false);
        concurrent.TryAdd("D#1", false);
        concurrent.TryAdd("E1", false);
        concurrent.TryAdd("F1", false);
        concurrent.TryAdd("F#1", false);
        concurrent.TryAdd("G1", false);
        concurrent.TryAdd("G#1", false);

        concurrent.TryAdd("A2", false);
        concurrent.TryAdd("A#2", false);
        concurrent.TryAdd("B2", false);
        concurrent.TryAdd("C2", false);
        concurrent.TryAdd("C#2", false);
        concurrent.TryAdd("D2", false);
        concurrent.TryAdd("D#2", false);
        concurrent.TryAdd("E2", false);
        concurrent.TryAdd("F2", false);
        concurrent.TryAdd("F#2", false);
        concurrent.TryAdd("G2", false);
        concurrent.TryAdd("G#2", false);

        concurrent.TryAdd("A3", false);
        concurrent.TryAdd("A#3", false);
        concurrent.TryAdd("B3", false);
        concurrent.TryAdd("C3", false);
        concurrent.TryAdd("C#3", false);
        concurrent.TryAdd("D3", false);
        concurrent.TryAdd("D#3", false);
        concurrent.TryAdd("E3", false);
        concurrent.TryAdd("F3", false);
        concurrent.TryAdd("F#3", false);
        concurrent.TryAdd("G3", false);
        concurrent.TryAdd("G#3", false);

        concurrent.TryAdd("A4", false);
        concurrent.TryAdd("A#4", false);
        concurrent.TryAdd("B4", false);
        concurrent.TryAdd("C4", false);
        /*concurrent.TryAdd("C#4", false);
        concurrent.TryAdd("D4", false);
        concurrent.TryAdd("D#4", false);
        concurrent.TryAdd("E4", false);
        concurrent.TryAdd("F4", false);
        concurrent.TryAdd("F#4", false);
        concurrent.TryAdd("G4", false);
        concurrent.TryAdd("G#4", false);

        concurrent.TryAdd("A5", false);
        concurrent.TryAdd("A#5", false);
        concurrent.TryAdd("B5", false);
        concurrent.TryAdd("C5", false);
        concurrent.TryAdd("C#5", false);
        concurrent.TryAdd("D5", false);
        concurrent.TryAdd("D#5", false);
        concurrent.TryAdd("E5", false);
        concurrent.TryAdd("F5", false);
        concurrent.TryAdd("F#5", false);
        concurrent.TryAdd("G5", false);
        concurrent.TryAdd("G#5", false);

        concurrent.TryAdd("A6", false);
        concurrent.TryAdd("A#6", false);
        concurrent.TryAdd("B6", false);
        concurrent.TryAdd("C6", false);
        concurrent.TryAdd("C#6", false);
        concurrent.TryAdd("D6", false);
        concurrent.TryAdd("D#6", false);
        concurrent.TryAdd("E6", false);
        concurrent.TryAdd("F6", false);
        concurrent.TryAdd("F#6", false);
        concurrent.TryAdd("G6", false);
        concurrent.TryAdd("G#6", false);

        concurrent.TryAdd("A7", false);
        concurrent.TryAdd("A#7", false);
        concurrent.TryAdd("B7", false);
        concurrent.TryAdd("C7", false);*/

        //concurrentTicks

        concurrentTicks.TryAdd("A0", new List<Notex>());
        concurrentTicks.TryAdd("A#0", new List<Notex>());
        concurrentTicks.TryAdd("B0", new List<Notex>());
        concurrentTicks.TryAdd("C0", new List<Notex>());
        concurrentTicks.TryAdd("C#0", new List<Notex>());
        concurrentTicks.TryAdd("D0", new List<Notex>());
        concurrentTicks.TryAdd("D#0", new List<Notex>());
        concurrentTicks.TryAdd("E0", new List<Notex>());
        concurrentTicks.TryAdd("F0", new List<Notex>());
        concurrentTicks.TryAdd("F#0", new List<Notex>());
        concurrentTicks.TryAdd("G0", new List<Notex>());
        concurrentTicks.TryAdd("G#0", new List<Notex>());

        concurrentTicks.TryAdd("A1", new List<Notex>());
        concurrentTicks.TryAdd("A#1", new List<Notex>());
        concurrentTicks.TryAdd("B1", new List<Notex>());
        concurrentTicks.TryAdd("C1", new List<Notex>());
        concurrentTicks.TryAdd("C#1", new List<Notex>());
        concurrentTicks.TryAdd("D1", new List<Notex>());
        concurrentTicks.TryAdd("D#1", new List<Notex>());
        concurrentTicks.TryAdd("E1", new List<Notex>());
        concurrentTicks.TryAdd("F1", new List<Notex>());
        concurrentTicks.TryAdd("F#1", new List<Notex>());
        concurrentTicks.TryAdd("G1", new List<Notex>());
        concurrentTicks.TryAdd("G#1", new List<Notex>());

        concurrentTicks.TryAdd("A2", new List<Notex>());
        concurrentTicks.TryAdd("A#2", new List<Notex>());
        concurrentTicks.TryAdd("B2", new List<Notex>());
        concurrentTicks.TryAdd("C2", new List<Notex>());
        concurrentTicks.TryAdd("C#2", new List<Notex>());
        concurrentTicks.TryAdd("D2", new List<Notex>());
        concurrentTicks.TryAdd("D#2", new List<Notex>());
        concurrentTicks.TryAdd("E2", new List<Notex>());
        concurrentTicks.TryAdd("F2", new List<Notex>());
        concurrentTicks.TryAdd("F#2", new List<Notex>());
        concurrentTicks.TryAdd("G2", new List<Notex>());
        concurrentTicks.TryAdd("G#2", new List<Notex>());

        concurrentTicks.TryAdd("A3", new List<Notex>());
        concurrentTicks.TryAdd("A#3", new List<Notex>());
        concurrentTicks.TryAdd("B3", new List<Notex>());
        concurrentTicks.TryAdd("C3", new List<Notex>());
        concurrentTicks.TryAdd("C#3", new List<Notex>());
        concurrentTicks.TryAdd("D3", new List<Notex>());
        concurrentTicks.TryAdd("D#3", new List<Notex>());
        concurrentTicks.TryAdd("E3", new List<Notex>());
        concurrentTicks.TryAdd("F3", new List<Notex>());
        concurrentTicks.TryAdd("F#3", new List<Notex>());
        concurrentTicks.TryAdd("G3", new List<Notex>());
        concurrentTicks.TryAdd("G#3", new List<Notex>());

        concurrentTicks.TryAdd("A4", new List<Notex>());
        concurrentTicks.TryAdd("A#4", new List<Notex>());
        concurrentTicks.TryAdd("B4", new List<Notex>());
        concurrentTicks.TryAdd("C4", new List<Notex>());
        concurrentTicks.TryAdd("C#4", new List<Notex>());
        concurrentTicks.TryAdd("D4", new List<Notex>());
        concurrentTicks.TryAdd("D#4", new List<Notex>());
        concurrentTicks.TryAdd("E4", new List<Notex>());
        concurrentTicks.TryAdd("F4", new List<Notex>());
        concurrentTicks.TryAdd("F#4", new List<Notex>());
        concurrentTicks.TryAdd("G4", new List<Notex>());
        concurrentTicks.TryAdd("G#4", new List<Notex>());

        concurrentTicks.TryAdd("A5", new List<Notex>());
        concurrentTicks.TryAdd("A#5", new List<Notex>());
        concurrentTicks.TryAdd("B5", new List<Notex>());
        concurrentTicks.TryAdd("C5", new List<Notex>());
        concurrentTicks.TryAdd("C#5", new List<Notex>());
        concurrentTicks.TryAdd("D5", new List<Notex>());
        concurrentTicks.TryAdd("D#5", new List<Notex>());
        concurrentTicks.TryAdd("E5", new List<Notex>());
        concurrentTicks.TryAdd("F5", new List<Notex>());
        concurrentTicks.TryAdd("F#5", new List<Notex>());
        concurrentTicks.TryAdd("G5", new List<Notex>());
        concurrentTicks.TryAdd("G#5", new List<Notex>());

        concurrentTicks.TryAdd("A6", new List<Notex>());
        concurrentTicks.TryAdd("A#6", new List<Notex>());
        concurrentTicks.TryAdd("B6", new List<Notex>());
        concurrentTicks.TryAdd("C6", new List<Notex>());
        concurrentTicks.TryAdd("C#6", new List<Notex>());
        concurrentTicks.TryAdd("D6", new List<Notex>());
        concurrentTicks.TryAdd("D#6", new List<Notex>());
        concurrentTicks.TryAdd("E6", new List<Notex>());
        concurrentTicks.TryAdd("F6", new List<Notex>());
        concurrentTicks.TryAdd("F#6", new List<Notex>());
        concurrentTicks.TryAdd("G6", new List<Notex>());
        concurrentTicks.TryAdd("G#6", new List<Notex>());

        concurrentTicks.TryAdd("A7", new List<Notex>());
        concurrentTicks.TryAdd("A#7", new List<Notex>());
        concurrentTicks.TryAdd("B7", new List<Notex>());
        concurrentTicks.TryAdd("C7", new List<Notex>());

        //objects

        /*objects.Add("A0", GameObject.Find("A0"));
        objects.Add("A#0", GameObject.Find("A#0"));
        objects.Add("B0", GameObject.Find("B0"));*/
        objects.Add("C0", GameObject.Find("C0"));
        objects.Add("C#0", GameObject.Find("C#0"));
        objects.Add("D0", GameObject.Find("D0"));
        objects.Add("D#0", GameObject.Find("D#0"));
        objects.Add("E0", GameObject.Find("E0"));
        objects.Add("F0", GameObject.Find("F0"));
        objects.Add("F#0", GameObject.Find("F#0"));
        objects.Add("G0", GameObject.Find("G0"));
        objects.Add("G#0", GameObject.Find("G#0"));

        objects.Add("A1", GameObject.Find("A1"));
        objects.Add("A#1", GameObject.Find("A#1"));
        objects.Add("B1", GameObject.Find("B1"));
        objects.Add("C1", GameObject.Find("C1"));
        objects.Add("C#1", GameObject.Find("C#1"));
        objects.Add("D1", GameObject.Find("D1"));
        objects.Add("D#1", GameObject.Find("D#1"));
        objects.Add("E1", GameObject.Find("E1"));
        objects.Add("F1", GameObject.Find("F1"));
        objects.Add("F#1", GameObject.Find("F#1"));
        objects.Add("G1", GameObject.Find("G1"));
        objects.Add("G#1", GameObject.Find("G#1"));

        objects.Add("A2", GameObject.Find("A2"));
        objects.Add("A#2", GameObject.Find("A#2"));
        objects.Add("B2", GameObject.Find("B2"));
        objects.Add("C2", GameObject.Find("C2"));
        objects.Add("C#2", GameObject.Find("C#2"));
        objects.Add("D2", GameObject.Find("D2"));
        objects.Add("D#2", GameObject.Find("D#2"));
        objects.Add("E2", GameObject.Find("E2"));
        objects.Add("F2", GameObject.Find("F2"));
        objects.Add("F#2", GameObject.Find("F#2"));
        objects.Add("G2", GameObject.Find("G2"));
        objects.Add("G#2", GameObject.Find("G#2"));

        objects.Add("A3", GameObject.Find("A3"));
        objects.Add("A#3", GameObject.Find("A#3"));
        objects.Add("B3", GameObject.Find("B3"));
        objects.Add("C3", GameObject.Find("C3"));
        objects.Add("C#3", GameObject.Find("C#3"));
        objects.Add("D3", GameObject.Find("D3"));
        objects.Add("D#3", GameObject.Find("D#3"));
        objects.Add("E3", GameObject.Find("E3"));
        objects.Add("F3", GameObject.Find("F3"));
        objects.Add("F#3", GameObject.Find("F#3"));
        objects.Add("G3", GameObject.Find("G3"));
        objects.Add("G#3", GameObject.Find("G#3"));

        objects.Add("A4", GameObject.Find("A4"));
        objects.Add("A#4", GameObject.Find("A#4"));
        objects.Add("B4", GameObject.Find("B4"));
        objects.Add("C4", GameObject.Find("C4"));
        /*objects.Add("C#4", GameObject.Find("C#4"));
        objects.Add("D4", GameObject.Find("D4"));
        objects.Add("D#4", GameObject.Find("D#4"));
        objects.Add("E4", GameObject.Find("E4"));
        objects.Add("F4", GameObject.Find("F4"));
        objects.Add("F#4", GameObject.Find("F#4"));
        objects.Add("G4", GameObject.Find("G4"));
        objects.Add("G#4", GameObject.Find("G#4"));

        objects.Add("A5", GameObject.Find("A5"));
        objects.Add("A#5", GameObject.Find("A#5"));
        objects.Add("B5", GameObject.Find("B5"));
        objects.Add("C5", GameObject.Find("C5"));
        objects.Add("C#5", GameObject.Find("C#5"));
        objects.Add("D5", GameObject.Find("D5"));
        objects.Add("D#5", GameObject.Find("D#5"));
        objects.Add("E5", GameObject.Find("E5"));
        objects.Add("F5", GameObject.Find("F5"));
        objects.Add("F#5", GameObject.Find("F#5"));
        objects.Add("G5", GameObject.Find("G5"));
        objects.Add("G#5", GameObject.Find("G#5"));

        objects.Add("A6", GameObject.Find("A6"));
        objects.Add("A#6", GameObject.Find("A#6"));
        objects.Add("B6", GameObject.Find("B6"));
        objects.Add("C6", GameObject.Find("C6"));
        objects.Add("C#6", GameObject.Find("C#6"));
        objects.Add("D6", GameObject.Find("D6"));
        objects.Add("D#6", GameObject.Find("D#6"));
        objects.Add("E6", GameObject.Find("E6"));
        objects.Add("F6", GameObject.Find("F6"));
        objects.Add("F#6", GameObject.Find("F#6"));
        objects.Add("G6", GameObject.Find("G6"));
        objects.Add("G#6", GameObject.Find("G#6"));

        objects.Add("A7", GameObject.Find("A7"));
        objects.Add("A#7", GameObject.Find("A#7"));
        objects.Add("B7", GameObject.Find("B7"));
        objects.Add("C7", GameObject.Find("C7"));*/


        gobjects.Add(36, GameObject.Find("C0"));
        Debug.Log(gobjects[36].name + "NAME1");
        gobjects.Add(37, GameObject.Find("C#0"));
        gobjects.Add(38, GameObject.Find("D0"));
        gobjects.Add(39, GameObject.Find("D#0"));
        gobjects.Add(40, GameObject.Find("E0"));
        gobjects.Add(41, GameObject.Find("F0"));
        gobjects.Add(42, GameObject.Find("F#0"));
        gobjects.Add(43, GameObject.Find("G0"));
        gobjects.Add(44, GameObject.Find("G#0"));

        gobjects.Add(45, GameObject.Find("A1"));
        gobjects.Add(46, GameObject.Find("A#1"));
        gobjects.Add(47, GameObject.Find("B1"));
        gobjects.Add(48, GameObject.Find("C1"));
        gobjects.Add(49, GameObject.Find("C#1"));
        gobjects.Add(50, GameObject.Find("D1"));
        gobjects.Add(51, GameObject.Find("D#1"));
        gobjects.Add(52, GameObject.Find("E1"));
        gobjects.Add(53, GameObject.Find("F1"));
        gobjects.Add(54, GameObject.Find("F#1"));
        gobjects.Add(55, GameObject.Find("G1"));
        gobjects.Add(56, GameObject.Find("G#1"));

        gobjects.Add(57, GameObject.Find("A2"));
        gobjects.Add(58, GameObject.Find("A#2"));
        gobjects.Add(59, GameObject.Find("B2"));
        gobjects.Add(60, GameObject.Find("C2"));
        gobjects.Add(61, GameObject.Find("C#2"));
        gobjects.Add(62, GameObject.Find("D2"));
        gobjects.Add(63, GameObject.Find("D#2"));
        gobjects.Add(64, GameObject.Find("E2"));
        gobjects.Add(65, GameObject.Find("F2"));
        gobjects.Add(66, GameObject.Find("F#2"));
        gobjects.Add(67, GameObject.Find("G2"));
        gobjects.Add(68, GameObject.Find("G#2"));

        gobjects.Add(69, GameObject.Find("A3"));
        gobjects.Add(70, GameObject.Find("A#3"));
        gobjects.Add(71, GameObject.Find("B3"));
        gobjects.Add(72, GameObject.Find("C3"));
        gobjects.Add(73, GameObject.Find("C#3"));
        gobjects.Add(74, GameObject.Find("D3"));
        gobjects.Add(75, GameObject.Find("D#3"));
        gobjects.Add(76, GameObject.Find("E3"));
        gobjects.Add(77, GameObject.Find("F3"));
        gobjects.Add(78, GameObject.Find("F#3"));
        gobjects.Add(79, GameObject.Find("G3"));
        gobjects.Add(80, GameObject.Find("G#3"));

        gobjects.Add(81, GameObject.Find("A4"));
        gobjects.Add(82, GameObject.Find("A#4"));
        gobjects.Add(83, GameObject.Find("B4"));
        gobjects.Add(84, GameObject.Find("C4"));

        foreach (int i in gobjects.Keys)
        {
            gobjects[i].GetComponent<Touche3>().number = i;
        }

        for (int i = 0; i < 49; i++)
        {
            concurrentInt.TryAdd(36 + i, 0);
        }

        Debug.Log(concurrent.Count() + " / " + objects.Count());
        S = new string[Directory.GetFiles("Assets/Music", "*.mid").Length];
        S = Directory.GetFiles("Assets/Music", "*.mid");
        musicString = S[currentMusic];
        BeforePlaying();
        S = Directory.GetFiles("Assets/Music", "*.mid");
        string x = S[currentMusic++];
        int b = x.IndexOf("\\");
        /*InitializeOutputDevice();
        var midiFile = CreateTestFile();
        InitializeFilePlayback(midiFile);
        StartPlayback();*/
    }
    void PressButton()
    {
        /*InitializeOutputDevice();
        var midiFile = CreateTestFile();
        InitializeFilePlayback(midiFile);
        _playback.Speed = speed;
        StartPlayback();*/
    }
    void BeforePlaying()
    {
        isBefore = true;
        midiFile = CreateTestFile();
        /*InitializeFilePlayback(midiFile);
        _playback.Speed = 1f;
        baseTicks = DateTime.Now.Ticks;
        StartPlayback();*/
        notes = midiFile.GetNotes();
        //Debug.Log("Besbes");
        /*foreach (Note n in notes)
        {
            var y = n.NoteName.ToString();
            if (y.Length >= 3)
            {
                var z = y[0] + "#";
                Debug.Log(z + (n.Octave - 1) + "/" + n.Length + "/" + n.Time);
                Notex nx = new Notex();
                nx.onOff = true;
                nx.velocity = n.Velocity;
                //concurrentTicks[z + (n.Octave - 1)].Add(nx);

            }
            else
            {
                Debug.Log(y + (n.Octave - 1) + "/" + n.Length + "/" + n.Time);
                Notex nx = new Notex();
                nx.ticks = DateTime.Now.Ticks - baseTicks;
                nx.onOff = true;
                nx.velocity = n.Velocity;
                //concurrentTicks[y + (n.Octave - 1)].Add(nx);
            }
        }*/
    }

    void Place()
    {
        /*foreach(string s in concurrentTicks.Keys) 
        {
            for (int i = 1; i < concurrentTicks[s].Count; i+=2)
            {
                try
                {
                    if (!concurrentTicks[s][i].onOff && concurrentTicks[s][i - 1].onOff)
                    {
                        float scale = (concurrentTicks[s][i].ticks - concurrentTicks[s][i-1].ticks) / 10000000f;
                        float x = objects[s].transform.position.x;
                        float y = concurrentTicks[s][i-1].ticks / 10000000f;
                        GameObject g = Instantiate(gm, new Vector3(x, y, 0), Quaternion.identity);
                        if (s.Length == 2)
                        {
                            g.transform.localScale = new Vector3(0.08f, scale, 1);
                            g.GetComponent<SpriteRenderer>().color = Color.magenta;
                        }
                        else
                        {
                            g.transform.localScale = new Vector3(0.05f, scale, 1);
                            g.GetComponent<SpriteRenderer>().color = Color.blue;
                        }
                        //g.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f);
                        //l.Add(g);
                        g.transform.parent = parent.transform;
                    }
                    else
                    {
                        Debug.Log("!!!!!!!!!!!!!!!!!");
                    }
                }
                catch
                {

                }
            }
            isFalling = true;
        }*/
        isPlaced = true;
        foreach (Note n in notes)
        {
            try
            {
                var a = n.NoteName.ToString();
                if (a.Length >= 2)
                {
                    a = a[0] + "#";
                    /*Debug.Log(y + (n.Octave - 1) + "/" + n.Length + "/" + n.Time);
                    Notex nx = new Notex();
                    nx.onOff = true;
                    nx.velocity = n.Velocity;
                    //concurrentTicks[z + (n.Octave - 1)].Add(nx);*/

                }
                /* else
                 {
                     Debug.Log(y + (n.Octave - 1) + "/" + n.Length + "/" + n.Time);
                     Notex nx = new Notex();
                     nx.ticks = DateTime.Now.Ticks - baseTicks;
                     nx.onOff = true;
                     nx.velocity = n.Velocity;
                     //concurrentTicks[y + (n.Octave - 1)].Add(nx);
                 }*/
                var z = a + (n.Octave - 2);
                float scale = (n.EndTime - n.Time) / 1500f;
                float x = objects[z].transform.position.x; ;
                if (z.Length == 3)
                {
                    x = objects[z].transform.position.x;
                }
                else
                {
                    x = objects[z].transform.GetChild(0).transform.position.x;
                }
                float y = n.Time / 500f;
                GameObject g = Instantiate(gm, new Vector3(x, y, 0), Quaternion.identity);
                if (z.Length == 2)
                {
                    g.transform.localScale = new Vector3(0.1f, scale, 1);
                    g.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, n.Velocity / 255f + 0.5f);
                    /*g.transform.GetChild(0).transform.localScale = new Vector2(g.transform.GetChild(0).transform.localScale.x, g.transform.GetChild(0).transform.localScale.y / scale);
                    g.transform.GetChild(1).transform.localScale = new Vector2(g.transform.GetChild(0).transform.localScale.x, g.transform.GetChild(0).transform.localScale.y / scale);*/
                }
                else
                {
                    g.transform.localScale = new Vector3(0.06f, scale, 1);
                    g.GetComponent<SpriteRenderer>().color = new Color(0, 0, 1, n.Velocity / 255f + 0.5f);
                    /*g.transform.GetChild(0).transform.localScale = new Vector2(g.transform.GetChild(0).transform.localScale.x, g.transform.GetChild(0).transform.localScale.y / scale);
                    g.transform.GetChild(1).transform.localScale = new Vector2(g.transform.GetChild(0).transform.localScale.x, g.transform.GetChild(0).transform.localScale.y / scale);*/
                }
                //g.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1.5f);
                //l.Add(g);
                g.transform.parent = parent.transform;
                isFalling = true;
            }
            catch
            {

            }
        }
    }
    private void OnApplicationQuit()
    {
        inputDevice.EventReceived -= OnEventReceived;
        inputDevice.Dispose();
        //using (var inputDevice = InputDevice.GetByName("Keystation 49"))
        {
            Debug.Log("XXX=" + inputDevice.Name);
            //inputDevice.EventReceived -= OnEventReceivedx;
        }
        /*var input = InputDevice.GetByName("Keystation 49");
        input.StopEventsListening();*/

        Debug.Log("Releasing playback and device...");

        if (_playback != null)
        {
            _playback.NotesPlaybackStarted -= OnNotesPlaybackStarted;
            _playback.NotesPlaybackFinished -= OnNotesPlaybackFinished;
            _playback.Dispose();
        }
        /*
        if (_outputDevice != null)
            _outputDevice.Dispose();
        */
        Debug.Log("Playback and device releasedxxx.");
    }

    private void InitializeOutputDevice()
    {
        Debug.Log($"Initializing output device [{OutputDeviceName}]...");

        var allOutputDevices = OutputDevice.GetAll();
        if (!allOutputDevices.Any(d => d.Name == OutputDeviceName))
        {
            var allDevicesList = string.Join(Environment.NewLine, allOutputDevices.Select(d => $"  {d.Name}"));
            Debug.Log($"There is no [{OutputDeviceName}] device presented in the system. Here the list of all device:{Environment.NewLine}{allDevicesList}");
            return;
        }

        _outputDevice = OutputDevice.GetByName(OutputDeviceName);
        Debug.Log($"Output device [{OutputDeviceName}] initialized.");
    }
    private void OnEventReceived(object sender, MidiEventReceivedEventArgs e)
    {
        Debug.Log(e.Event.ToString());
        if (e.Event.ToString().Contains("Note On"))
        {
            Debug.Log("ABC");
            //Debug.Log(gobjects[36].name + "NAME2");
            string s = e.Event.ToString();
            int ind1 = s.IndexOf("(");
            string s1 = s.Substring(ind1 + 1);
            int ind2 = s1.IndexOf(")");
            string s2 = s1.Substring(0, ind2);
            //Debug.Log(s2);
            string[] ind = s2.Split(',');
            string s3 = ind[0].Trim();
            string s4 = ind[1].Trim();
            int note = int.Parse(s3);
            int type = int.Parse(s4);
            if (type != 0)
            {
                if (note == 53)
                {
                    goToTraining = true;
                }
                else if (note == 67)
                {
                    goToPlay = true;
                }
                else if (note == 60)
                {
                    goToFree = true;
                }
                NoteOnEvent noe = new NoteOnEvent();
                //noe.Channel =(SevenBitNumber)1;
                //noe.NoteNumber = (SevenBitNumber)((int)(byte)e.GetHashCode());
                noe.NoteNumber = (SevenBitNumber)note;
                Debug.Log(note + "XX");
                noe.Velocity = (SevenBitNumber)type;
                //Debug.Log(type);
                /*Debug.Log(objects.Count + "(Count)");
                foreach (GameObject go in objects.Values)
                {
                    Debug.Log(go.GetComponent<Touche>().number + "ZZ");
                    if (go.GetComponent<Touche>().number == note)
                    {
                        Debug.Log("ABC1");
                        go.GetComponent<Touche>().Pressed();

                        break;
                    }
                }*/
                //Debug.Log(gobjects[36].name + "NAME3");
                //callbacks.Enqueue(OnThreadCompleted);
                concurrentInt.TryUpdate(note, 2, 0);
                _outputDevice.SendEvent(noe);
            }
            else
            {
                NoteOffEvent noe = new NoteOffEvent();
                //noe.Channel =(SevenBitNumber)1;
                //noe.NoteNumber = (SevenBitNumber)((int)(byte)e.GetHashCode());
                noe.NoteNumber = (SevenBitNumber)note;
                Debug.Log(note + "XX");
                noe.Velocity = (SevenBitNumber)0;
                //Debug.Log(type);
                /*Debug.Log(objects.Count + "lol");
                foreach (GameObject go in objects.Values)
                {
                    Debug.Log(go.GetComponent<Touche>().number + "ZZ");
                    if (go.GetComponent<Touche>().number == note)
                    {
                        Debug.Log("ABC2");
                        go.GetComponent<SpriteRenderer>().color = Color.clear;
                        break;
                    }
                }*/
                //Debug.Log(gobjects[36].name + "NAME4");
                //gobjects[36].GetComponent<SpriteRenderer>().color = Color.clear;
                //callbacks.Enqueue(OnThread2Completed);
                concurrentInt.TryUpdate(note, 1, 2);
                Debug.Log(concurrentInt[note]);
                _outputDevice.SendEvent(noe);
            }
        }
        else if (e.Event.ToString().Contains("Program Change"))
        {
            Debug.Log(e.Event.ToString());
            string s = e.Event.ToString();
            int ind1 = s.IndexOf("(");
            string s1 = s.Substring(ind1 + 1);
            int ind2 = s1.IndexOf(")");
            string s2 = s1.Substring(0, ind2);
            int oct = int.Parse(s2);
            Debug.Log(oct + "OCTAVE!");
        }
    }
    /*private void OnThreadCompleted()
    {
        Debug.Log("lol");
        gobjects[36].GetComponent<Touche>().Pressed();
    }
    private void OnThread2Completed()
    {
        Debug.Log("mdr");
        gobjects[36].GetComponent<SpriteRenderer>().color = Color.clear;
    }*/
    public void OnTuileEnter(int n, float i)
    {
        NoteOnEvent noe = new NoteOnEvent();
        //noe.Channel =(SevenBitNumber)1;
        //noe.NoteNumber = (SevenBitNumber)((int)(byte)e.GetHashCode());
        noe.NoteNumber = (SevenBitNumber)n;
        noe.Velocity = (SevenBitNumber)i;
        _outputDevice.SendEvent(noe);
    }
    public void OnTuileExit(int n)
    {
        NoteOffEvent noe = new NoteOffEvent();
        //noe.Channel =(SevenBitNumber)1;
        //noe.NoteNumber = (SevenBitNumber)((int)(byte)e.GetHashCode());
        noe.NoteNumber = (SevenBitNumber)n;
        noe.Velocity = (SevenBitNumber)0;
        _outputDevice.SendEvent(noe);
    }
    private MidiFile CreateTestFile()
    {
        Debug.Log("Creating test MIDI file...");

        /*var patternBuilder = new PatternBuilder()
            .SetNoteLength(MusicalTimeSpan.Eighth)
            .SetVelocity(SevenBitNumber.MaxValue)
            .ProgramChange(GeneralMidiProgram.Harpsichord);

        foreach (var noteNumber in SevenBitNumber.Values)
        {
            patternBuilder.Note(Melanchall.DryWetMidi.MusicTheory.Note.Get(noteNumber));
        }

        var midiFile = patternBuilder.Build().ToFile(TempoMap.Default);*/
        var midiFile = MidiFile.Read(musicString, null);
        Debug.Log("Test MIDI file created.");

        return midiFile;
    }

    private void InitializeFilePlayback(MidiFile midiFile)
    {
        Debug.Log("Initializing playback...");

        _playback = midiFile.GetPlayback(_outputDevice);
        _playback.Loop = false;
        _playback.NotesPlaybackStarted += OnNotesPlaybackStarted;
        _playback.NotesPlaybackFinished += OnNotesPlaybackFinished;

        Debug.Log("Playback initialized.");
    }
    private void StartPlayback()
    {
        Debug.Log("Starting playback...");
        _playback.Start();
    }

    private void OnNotesPlaybackFinished(object sender, NotesEventArgs e)
    {
        long ll = DateTime.Now.Ticks;
        /*if (!isBefore)
        {
            LogNotes("Notes finished:", e);
            List<Note> eList = e.Notes.ToList();
            string eString = "" + eList[eList.Count - 1];
            concurrent[eString] = false;
        }
        else*/
        {
            var x = e.Notes;
            foreach (Note n in x)
            {
                var y = n.NoteName.ToString();
                if (y.Length >= 3)
                {
                    var z = y[0] + "#";
                    Debug.Log(z + (n.Octave - 1));
                    Notex nx = new Notex();
                    nx.ticks = ll - baseTicks;
                    nx.onOff = false;
                    nx.velocity = n.Velocity;
                    concurrentTicks[z + (n.Octave - 1)].Add(nx);
                }
                else
                {
                    Debug.Log(y + (n.Octave - 1));
                    Notex nx = new Notex();
                    nx.ticks = DateTime.Now.Ticks - baseTicks;
                    nx.onOff = false;
                    nx.velocity = n.Velocity;
                    concurrentTicks[y + (n.Octave - 1)].Add(nx);
                }
            }
        }
    }

    private void OnNotesPlaybackStarted(object sender, NotesEventArgs e)
    {
        long ll = DateTime.Now.Ticks;
        /*if (!isBefore)
        {
            LogNotes("Notes started:", e);
            List<Note> eList = e.Notes.ToList();
            string eString = "" + eList[eList.Count - 1];
            concurrent[eString] = true;
        }
        else*/
        {
            /*List<Note> eList = e.Notes.ToList();
            string eString = "" + eList[eList.Count - 1];*/
            var x = e.Notes;
            foreach (Note n in x)
            {
                var y = n.NoteName.ToString();
                if (y.Length >= 3)
                {
                    var z = y[0] + "#";
                    Debug.Log(z + (n.Octave - 1));
                    Notex nx = new Notex();
                    nx.ticks = ll - baseTicks;
                    nx.onOff = true;
                    nx.velocity = n.Velocity;
                    concurrentTicks[z + (n.Octave - 1)].Add(nx);

                }
                else
                {
                    Debug.Log(y + (n.Octave - 1));
                    Notex nx = new Notex();
                    nx.ticks = DateTime.Now.Ticks - baseTicks;
                    nx.onOff = true;
                    nx.velocity = n.Velocity;
                    concurrentTicks[y + (n.Octave - 1)].Add(nx);
                }
            }
        }
    }

    private void LogNotes(string title, NotesEventArgs e)
    {
        var message = new StringBuilder()
            .AppendLine(title)
            .AppendLine(string.Join(Environment.NewLine, e.Notes.Select(n => $"  {n}")))
            .ToString();
        Debug.Log(message.Trim());
    }
    private void Update()
    {
        if (goToFree)
        {
            SceneManager.LoadScene(2);
        }
        if (goToPlay)
        {
            SceneManager.LoadScene(1);
        }
        if (goToTraining)
        {

        }
        foreach (int i in concurrentInt.Keys)
        {
            if (concurrentInt[i] == 2)
            {
                gobjects[i].GetComponent<Touche3>().Pressed();
                concurrentInt.TryUpdate(i, 0, 1);
            }
            if (concurrentInt[i] == 1)
            {
                gobjects[i].GetComponent<SpriteRenderer>().color = Color.clear;
                concurrentInt.TryUpdate(i, 0, 1);
            }
        }
    }
}