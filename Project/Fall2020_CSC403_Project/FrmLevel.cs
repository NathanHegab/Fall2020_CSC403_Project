using Fall2020_CSC403_Project.code;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fall2020_CSC403_Project {
    public partial class FrmLevel : Form {
        private Player player;

        private HealthPack healthPack;

        private Enemy enemyPoisonPacket;
        private Enemy bossKoolaid;
        private Enemy enemyCheeto;
        private Character[] walls;

        private DateTime timeBegin;
        private FrmBattle frmBattle;

        private FrmInventory frmInventory;
        private Sword diamondSword;
        private Sword daedricSword;
        private Sword keyblade;

        public FrmLevel() {
            InitializeComponent();
        }

        private void FrmLevel_Load(object sender, EventArgs e) {
            const int PADDING = 7;
            const int NUM_WALLS = 13;

            player = new Player(CreatePosition(picPlayer), CreateCollider(picPlayer, PADDING));
            healthPack = new HealthPack(CreatePosition(picHealthpack), CreateCollider(picHealthpack, PADDING), 10);
            bossKoolaid = new Enemy(CreatePosition(picBossKoolAid), CreateCollider(picBossKoolAid, PADDING));
            enemyPoisonPacket = new Enemy(CreatePosition(picEnemyPoisonPacket), CreateCollider(picEnemyPoisonPacket, PADDING));
            enemyCheeto = new Enemy(CreatePosition(picEnemyCheeto), CreateCollider(picEnemyCheeto, PADDING));

            // create sword objects associated with pictures
            diamondSword = new Sword(CreatePosition(picDiamondSword), CreateCollider(picDiamondSword, PADDING), "Minecraft's famous Diamond Sword! (Grants 4 additional hit points on enemies!)", picDiamondSword.Image, -2);
            daedricSword = new Sword(CreatePosition(picDaedricSword), CreateCollider(picDaedricSword, PADDING), "Crafted from the hearts of your Daedric enemies! (Grants 10 additional hit points on enemies!)", picDaedricSword.Image, -5);
            keyblade = new Sword(CreatePosition(picKeyblade), CreateCollider(picKeyblade, PADDING), "Kingdom Hearts fans should be familiar with this. (Grants 6 additional hit points on enemies!)", picKeyblade.Image, -3);


            healthPack.Img = picHealthpack.BackgroundImage;
            bossKoolaid.Img = picBossKoolAid.BackgroundImage;
            enemyPoisonPacket.Img = picEnemyPoisonPacket.BackgroundImage;
            enemyCheeto.Img = picEnemyCheeto.BackgroundImage;

            bossKoolaid.Color = Color.Red;
            enemyPoisonPacket.Color = Color.Green;
            enemyCheeto.Color = Color.FromArgb(255, 245, 161);

            walls = new Character[NUM_WALLS];
            for (int w = 0; w < NUM_WALLS; w++) {
                PictureBox pic = Controls.Find("picWall" + w.ToString(), true)[0] as PictureBox;
                walls[w] = new Character(CreatePosition(pic), CreateCollider(pic, PADDING));
            }

            Game.player = player;
            timeBegin = DateTime.Now;
        }

        private Vector2 CreatePosition(PictureBox pic) {
            return new Vector2(pic.Location.X, pic.Location.Y);
        }

        private Collider CreateCollider(PictureBox pic, int padding) {
            Rectangle rect = new Rectangle(pic.Location, new Size(pic.Size.Width - padding, pic.Size.Height - padding));
            return new Collider(rect);
        }

        private void FrmLevel_KeyUp(object sender, KeyEventArgs e) {
            player.ResetMoveSpeed();
        }

        private void tmrUpdateInGameTime_Tick(object sender, EventArgs e) {
            TimeSpan span = DateTime.Now - timeBegin;
            string time = span.ToString(@"hh\:mm\:ss");
            lblInGameTime.Text = "Time: " + time.ToString();
        }

        private void tmrPlayerMove_Tick(object sender, EventArgs e) {
            // move player
            player.Move();

            // check collision with walls
            if (HitAWall(player)) {
                player.MoveBack();
            }

            // check collision with health pack
            if (HitAHealthPack(player, healthPack)) {
                Heal(healthPack);
            }

            // check collision with enemies
            if (HitAChar(player, enemyPoisonPacket)) {
                Fight(enemyPoisonPacket);
            }
            else if (HitAChar(player, enemyCheeto)) {
                Fight(enemyCheeto);
            }
            if (HitAChar(player, bossKoolaid)) {
                Fight(bossKoolaid);
            }

            // check collision with swords
            if (HitSword(player, diamondSword)) {
                if (picDiamondSword.Image != null) {
                    AddToInventory(diamondSword);
                    picDiamondSword.Dispose();
                    picDiamondSword.Image = null;
                }
            }
            if (HitSword(player, daedricSword)) {
                if (picDaedricSword.Image != null) {
                    AddToInventory(daedricSword);
                    picDaedricSword.Dispose();
                    picDaedricSword.Image = null;
                }
            }
            if (HitSword(player, keyblade)) {
                if (picKeyblade.Image != null) {
                    AddToInventory(keyblade);
                    picKeyblade.Dispose();
                    picKeyblade.Image = null;
                }
            }

            // update player's picture box
            picPlayer.Location = new Point((int)player.Position.x, (int)player.Position.y);
        }

        private bool HitAWall(Character c) {
            bool hitAWall = false;
            for (int w = 0; w < walls.Length; w++) {
                if (c.Collider.Intersects(walls[w].Collider)) {
                    hitAWall = true;
                    break;
                }
            }
            return hitAWall;
        }

        private bool HitAHealthPack(Character you, HealthPack health) {
            return you.Collider.Intersects(health.Collider);
        }

        private bool HitAChar(Character you, Character other) {
            return you.Collider.Intersects(other.Collider);
        }


        private void Heal(HealthPack health) {
            if (player.Health < player.MaxHealth) {
                player.AlterHealth(health.HealthPoints);
                healthPack.EmptyHealthPack();
            }
        }

        // returns true when sword is hit
        private bool HitSword(Character you, Sword sword) {
            return you.Collider.Intersects(sword.Collider);
        }

        // add sword to inventory when hit
        private void AddToInventory(Sword sword) {
            frmInventory = FrmInventory.GetInstance();
            frmInventory.PutItemInInventory(sword);

        }

        private void Fight(Enemy enemy) {
            player.ResetMoveSpeed();
            player.MoveBack();
            frmBattle = FrmBattle.GetInstance(enemy);
            frmBattle.Show();

            if (enemy == bossKoolaid) {
                frmBattle.SetupForBossBattle();
            }
        }

        private void FrmLevel_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Left:
                    player.GoLeft();
                    break;

                case Keys.Right:
                    player.GoRight();
                    break;

                case Keys.Up:
                    player.GoUp();
                    break;

                case Keys.Down:
                    player.GoDown();
                    break;

                case Keys.W:
                    player.GoSprintUp();
                    break;

                case Keys.A:
                    player.GoSprintLeft();
                    break;

                case Keys.S:
                    player.GoSprintDown();
                    break;

                case Keys.D:
                    player.GoSprintRight();
                    break;

                case Keys.I:
                    player.GoSneakUp();
                    break;

                case Keys.J:
                    player.GoSneakLeft();
                    break;

                case Keys.K:
                    player.GoSneakDown();
                    break;

                case Keys.L:
                    player.GoSneakRight();
                    break;

                case Keys.N:
                    frmInventory = FrmInventory.GetInstance();
                    frmInventory.Show();
                    break;

                default:
                    player.ResetMoveSpeed();
                    break;
            }
        }

        private void lblInGameTime_Click(object sender, EventArgs e) {

        }
    }
}